using UnityEngine;

namespace Dwarf {
    public class StillMoveState : MoveState
    {
        public StillMoveState(PlayerMovement playerMovement) : base(playerMovement)
        {

        }

        public override void Init()
        {
            _playerMovement.moveState = MoveStateEnum.Still;
        }

        public override void FixedUpdate()
        {
            Vector3 movement =  new Vector3(0, _playerMovement.Velocity.y);
            _playerMovement.Velocity = movement;
        }
    }
}
