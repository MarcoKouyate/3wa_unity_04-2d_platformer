using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class RecoveryJumpState : JumpState
    {
        #region Constructor
        public RecoveryJumpState(PlayerMovement playerMovement) : base(playerMovement)
        {

        }
        #endregion

        #region Inherited Methods
        public override void Init()
        {
            _recoveryTime = Time.time + _playerMovement.RecoveryDuration;
            _playerMovement.jumpState = JumpStateEnum.Recovery;
        }

        public override void Update()
        {
            if(Time.time > _recoveryTime)
            {
                _playerMovement.SetJumpState(new GroundedJumpState(_playerMovement));
            }
        }
        #endregion

        private float _recoveryTime;
    }
}
