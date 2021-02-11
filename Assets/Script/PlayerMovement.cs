using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Show in inspector
        [SerializeField] private float _speed;
        [SerializeField] private PlayerAnimation _animation;
        public MoveStateEnum moveState;
        #endregion

        #region Properties
        public float Speed { get => _speed; }

        public Vector2 Velocity { 
            get => _rigidbody.velocity;
            set => _rigidbody.velocity = value;
        }
        #endregion

        #region State Machine
        public void SetMoveState(MoveState state)
        {
            _moveState = state;
            state.Init();
        }
        #endregion

        #region Unity Cycle
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            SetMoveState(new MovingState(this));
        }

        private void Update()
        {
            _moveState.Update();
        }

        private void FixedUpdate()
        {
            _moveState.FixedUpdate();
            _animation.SetVerticalSpeed(_rigidbody.velocity.y);
            _animation.SetHorizontalSpeed(_rigidbody.velocity.x);
        }
        #endregion

        public void LockMovement(bool isLock)
        {
            if(isLock)
            {
                SetMoveState(new StillMoveState(this));
            } else
            {
                SetMoveState(new MovingState(this));
            }
        }

        #region Private variables
        private Rigidbody2D _rigidbody;
        private MoveState _moveState;
        #endregion
    }
}
