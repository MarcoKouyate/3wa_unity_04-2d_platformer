using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {

    public enum JumpStateEnum { Grounded, Impulse, Jump, Recovery }
    public abstract class JumpState 
    {
        public JumpState(PlayerMovement playerMovement)
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
