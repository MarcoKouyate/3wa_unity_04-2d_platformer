using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerAnimationController _animation;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _jumpInterval;
        [SerializeField] LayerMask _groundLayers;
        [SerializeField] Transform _groundCheck;
        [SerializeField] private int _jumpCount;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _movement = Vector2.zero;
            _isJumping = false;
            _remainingJumps = _jumpCount;
        }

        private void Update()
        {
            DetectGround();
            JumpInput();
            MovementInput();
        }

        private bool IsGrounded() {
            return Physics2D.Raycast(transform.position, Vector2.down, 1f, _groundLayers);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawRay(transform.position, Vector2.down);
        }

        private void FixedUpdate()
        {

            _movement.y = _rigidbody.velocity.y + _jump;
            _jump = 0;
            _rigidbody.velocity = _movement;

            _animation.SetVerticalSpeed(_rigidbody.velocity.y);
            _animation.SetHorizontalSpeed(_rigidbody.velocity.x);
        }

        private void MovementInput()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            float inputMagnitude = Mathf.Clamp01(input.magnitude);
            input.Normalize();
            _movement = Vector2.right * input.x * _speed * inputMagnitude;

            if (input.x * transform.right.x < 0)
            {
                transform.Rotate(Vector2.up * 180);
            }
        }

        private void DetectGround()
        {
            _isGrounded = IsGrounded();
            _animation.IsGrounded(_isGrounded);
        }
        private void JumpInput()
        {
            if(_remainingJumps > 1 && Input.GetButtonDown("Jump")){
                _animation.Jump();
                _isJumping = true;
                _jumpTime = (_isGrounded) ? Time.time + _jumpInterval : Time.time;
            }

            if (_isJumping && Time.time > _jumpTime)
            {
                _isJumping = false;
                _remainingJumps--;
                _jump = _jumpHeight;
            }

            if (_isGrounded && !_isJumping)
            {
                _remainingJumps = _jumpCount;
            }
        }

        private int _remainingJumps;
        private bool _isGrounded;
        private bool _isJumping;
        private float _jumpTime;
        private float _jump;
        private Rigidbody2D _rigidbody;
        private Vector2 _movement;
    }
}
