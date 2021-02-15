using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class AirJumpState : JumpState
    {
        public AirJumpState(PlayerJump playerJump) : base(playerJump)
        {

        }

        public override void Init()
        {
            _playerJump.jumpState = JumpStateEnum.Jump;
            _remainingJumps = _playerJump.JumpCount;
            _jumpHeight = _playerJump.JumpHeight;
            _jumpTime = Time.time + _playerJump.ImpulseDuration;

            _isJumping = true;
            _playerJump.LockMovement(false);
        }

        public override void Update()
        {
            if (Time.time > _jumpTime && _playerJump.IsGrounded)
            {
                _playerJump.SetJumpState(new RecoveryJumpState(_playerJump));
            }

            if (_remainingJumps > 0 && Input.GetButtonDown("Jump"))
            {
                _isJumping = true;
            }
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
            Vector2 velocity = _playerJump.Velocity;
            velocity.y = _jumpHeight;
            _playerJump.Velocity = velocity;
            _isJumping = false;
            _remainingJumps--;
        }

        private float _jumpTime;
        private bool _isJumping;
        private int _remainingJumps;
        private float _jumpHeight;
    }
}
