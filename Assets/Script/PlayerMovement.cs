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
        [SerializeField] private float _impulseDuration;
        [SerializeField] private float _recoveryDuration;
        [SerializeField] LayerMask _groundLayers;
        [SerializeField] private int _jumpCount;

        public JumpStateEnum jumpState;

        public PlayerAnimationController Animation { get => _animation; }
        public int JumpCount { get => _jumpCount; }
        public float JumpHeight { get => _jumpHeight; }
        public float ImpulseDuration { get => _impulseDuration; }
        public float RecoveryDuration { get => _recoveryDuration; }

        public Vector2 Velocity { 
            get => _rigidbody.velocity;
            set => _rigidbody.velocity = value;
        }


        public void SetJumpState(JumpState state)
        {
            _movementState = state;
            state.Init();
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _movement = Vector2.zero;
            SetJumpState(new GroundedJumpState(this));
        }

        private void Update()
        {
            _animation.IsGrounded(IsGrounded());
            _movementState.Update();
        }

        private void FixedUpdate()
        {

            _movement.y = _rigidbody.velocity.y;
            _rigidbody.velocity = _movement;
            _movement = Vector2.zero;
            _movementState.FixedUpdate();

            _animation.SetVerticalSpeed(_rigidbody.velocity.y);
            _animation.SetHorizontalSpeed(_rigidbody.velocity.x);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawRay(transform.position, Vector2.down);
        }



        public bool IsGrounded()
        {
            return Physics2D.Raycast(transform.position, Vector2.down, 0.1f, _groundLayers);
        }


        public void Move()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _movement = Vector2.right * input.x * _speed;

            if (input.x * transform.right.x < 0)
            {
                transform.Rotate(Vector2.up * 180);
            }
        }

        private Rigidbody2D _rigidbody;
        private Vector2 _movement;

        private JumpState _movementState;
    }
}
