using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {

    public enum JumpStateEnum { Grounded, Impulse, Jump, Recovery }
    public abstract class JumpState 
    {
        public JumpState(PlayerJump playerJump)
        {
            _playerJump = playerJump;
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

        protected PlayerJump _playerJump;
    }
}
