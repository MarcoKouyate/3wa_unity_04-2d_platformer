using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {

    public class PlayerJump : MonoBehaviour
    {
        #region Show in inspector
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _impulseDuration;
        [SerializeField] private float _recoveryDuration;
        [SerializeField] private int _jumpCount;
        [SerializeField] private GroundChecker _groundCheck;
        [SerializeField] private PlayerAnimation _animation;

        public JumpStateEnum jumpState;
        #endregion

        #region Properties
        public PlayerAnimation Animation { get => _animation;  }
        public int JumpCount { get => _jumpCount; }
        public float JumpHeight { get => _jumpHeight; }
        public float ImpulseDuration { get => _impulseDuration; }
        public float RecoveryDuration { get => _recoveryDuration; }
        public bool IsGrounded { get => _groundCheck.IsGrounded(); }

        public Vector2 Velocity
        {
            get => _rigidbody.velocity;
            set => _rigidbody.velocity = value;
        }
        #endregion

        #region State Machine
        public void SetJumpState(JumpState state)
        {
            _jumpState = state;
            state.Init();
        }
        #endregion

        #region Unity Cycle
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerMovement = GetComponent<PlayerMovement>();
            SetJumpState(new GroundedJumpState(this));
        }

        private void Update()
        {
            _jumpState.Update();
            _animation.IsGrounded(IsGrounded);
        }

        private void FixedUpdate()
        {
            _jumpState.FixedUpdate();
        }
        #endregion

        public void LockMovement(bool isLock)
        {
            if(_playerMovement != null)
            {
                _playerMovement.LockMovement(isLock);
            } 
        }

        #region Private Variables
        private Rigidbody2D _rigidbody;
        private JumpState _jumpState;
        private PlayerMovement _playerMovement;
        #endregion
    }
}
