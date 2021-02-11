using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class PrepareJumpJumpState : JumpState
    {
        public PrepareJumpJumpState(PlayerMovement playerMovement) : base(playerMovement)
        {

        }

        public override void Init()
        {
            _playerMovement.Animation.Jump();
            _jumpTime = Time.time + _playerMovement.ImpulseDuration;
            _playerMovement.jumpState = JumpStateEnum.Impulse;
        }

        public override void Update()
        {
            if(Time.time > _jumpTime)
            {
                _playerMovement.SetJumpState(new AirJumpState(_playerMovement));
;           }
        }

        private float _jumpTime;
    }
}
