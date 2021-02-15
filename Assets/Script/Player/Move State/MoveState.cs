

namespace Dwarf {
    public enum MoveStateEnum {Still, Moving }

    public class MoveState
    {
        public MoveState(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }

        public virtual void Init()
        {
            
        }

        public virtual void Update()
        {

        }

        public virtual void FixedUpdate()
        {

        }

        protected PlayerMovement _playerMovement;
    }
}
