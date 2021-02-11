using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class GroundedJumpState : JumpState
    {
        public GroundedJumpState(PlayerMovement playerMovement) : base(playerMovement)
        {

        }

        public override void Init()
        {
            _playerMovement.jumpState = JumpStateEnum.Grounded;
        }

        public override void Update()
        {
            _playerMovement.Move();

            if (Input.GetButtonDown("Jump"))
            {
                _playerMovement.SetJumpState(new PrepareJumpJumpState(_playerMovement));
            }
        }
    }
}
