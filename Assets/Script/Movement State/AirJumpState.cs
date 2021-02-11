using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class AirJumpState : JumpState
    {
        public AirJumpState(PlayerMovement playerMovement) : base(playerMovement)
        {

        }

        public override void Init()
        {
            _playerMovement.jumpState = JumpStateEnum.Jump;
            _remainingJumps = _playerMovement.JumpCount;
            _jumpHeight = _playerMovement.JumpHeight;
            _jumpTime = Time.time + _playerMovement.ImpulseDuration;

            _isJumping = true;
        }

        public override void Update()
        {
            if (Time.time > _jumpTime && _playerMovement.IsGrounded())
            {
                _playerMovement.SetJumpState(new RecoveryJumpState(_playerMovement));
            }

            if (_remainingJumps > 0 && Input.GetButtonDown("Jump"))
            {
                _isJumping = true;
            }

            _playerMovement.Move();
        }

        public override void FixedUpdate()
        {
            if(_isJumping)
            {
                Jump();
            }
        }

        private void Jump()
        {
            Vector2 velocity = _playerMovement.Velocity;
            velocity.y = _jumpHeight;
            _playerMovement.Velocity = velocity;
            _isJumping = false;
            _remainingJumps--;
        }

        private float _jumpTime;
        private bool _isJumping;
        private int _remainingJumps;
        private float _jumpHeight;
    }
}
