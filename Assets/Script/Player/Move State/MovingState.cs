using UnityEngine;

namespace Dwarf {
    public class MovingState : MoveState
    {
        #region Constructor
        public MovingState(PlayerMovement playerMovement) : base(playerMovement) { }
        #endregion

        #region Inherited Methods
        public override void Init()
        {
            _playerMovement.moveState = MoveStateEnum.Moving; 
        }

        public override void Update()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _movement = Vector2.right * input.x * _playerMovement.Speed;

            if (input.x * _playerMovement.transform.right.x < 0)
            {
                _playerMovement.transform.Rotate(Vector2.up * 180);
            }
        }

        public override void FixedUpdate()
        {
            _movement.y = _playerMovement.Velocity.y;
            _playerMovement.Velocity = _movement;
        }

        private Vector2 _movement = Vector2.zero;

        #endregion
    }
}
