using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class ImpulseJumpState : JumpState
    {
        #region Constructor
        public ImpulseJumpState(PlayerJump playerJump) : base(playerJump)
        {

        }
        #endregion

        #region Inherited Methods
        public override void Init()
        {
            _playerJump.Animation.Jump();
            _jumpTime = Time.time + _playerJump.ImpulseDuration;
            _playerJump.jumpState = JumpStateEnum.Impulse;
            _playerJump.LockMovement(true);
        }

        public override void Update()
        {
            if(Time.time > _jumpTime)
            {
                _playerJump.SetJumpState(new AirJumpState(_playerJump));
            }
        }
        #endregion

        private float _jumpTime;
    }
}
