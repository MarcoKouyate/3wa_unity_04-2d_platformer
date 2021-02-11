using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class RecoveryJumpState : JumpState
    {
        #region Constructor
        public RecoveryJumpState(PlayerJump playerJump) : base(playerJump)
        {

        }
        #endregion

        #region Inherited Methods
        public override void Init()
        {
            _recoveryTime = Time.time + _playerJump.RecoveryDuration;
            _playerJump.jumpState = JumpStateEnum.Recovery;
            _playerJump.LockMovement(true);
        }

        public override void Update()
        {
            if(Time.time > _recoveryTime)
            {
                _playerJump.SetJumpState(new GroundedJumpState(_playerJump));
            }
        }
        #endregion

        private float _recoveryTime;
    }
}
