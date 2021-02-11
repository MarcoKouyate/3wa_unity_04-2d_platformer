using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class GroundedJumpState : JumpState
    {
        #region Constructor
        public GroundedJumpState(PlayerJump playerJump) : base(playerJump)
        {

        }
        #endregion

        #region Inherited Methods
        public override void Init()
        {
            _playerJump.jumpState = JumpStateEnum.Grounded;
            _playerJump.LockMovement(false);
        }

        public override void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                _playerJump.SetJumpState(new ImpulseJumpState(_playerJump));
            }
        }
        #endregion
    }
}
