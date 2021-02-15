using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class FallingHingeJoint : MonoBehaviour
    {
        #region Show in Inspector
        [SerializeField] private FallingHingeJoint _selfPrebab;
        [SerializeField] private float _timeBeforeBreak;
        [SerializeField] private float _timeBeforeRespawn;
        #endregion


        #region Setters
        public void SetBreakTime(float timeBeforeBreak)
        {
            _timeBeforeBreak = timeBeforeBreak;
        }

        public void SetRespawnTime(float timeBeforeRespawn)
        {
            _timeBeforeRespawn = timeBeforeRespawn;
        }
        #endregion


        #region Unity Cycle
        private void Awake()
        {
            _hingeJoint2D = GetComponent<HingeJoint2D>();
            _startPosition = transform.position;
            _startRotation = transform.rotation;
        }

        private void Update()
        {
            if (_shouldFall)
            {
                OnBreak();
            }
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _shouldFall = true;
                _breakTime = Time.time + _timeBeforeBreak;
                _respawnTime = _breakTime + _timeBeforeRespawn;

            }
        }
        #endregion


        #region Public Methods
        public void Break()
        {
            _hingeJoint2D.enabled = false;
        }

        public void Lock()
        {
            _hingeJoint2D.enabled = true;
        }
        #endregion


        #region When Breaking
        private void OnBreak()
        {
            if (Time.time > _respawnTime)
            {
                Respawn();
            } else if (Time.time > _breakTime)
            {
                Break();
            }
        }

        private void Respawn()
        {

            foreach (Transform child in transform)
            {
                if (child.CompareTag("Player"))
                {
                    child.SetParent(null);
                }
            }

            FallingHingeJoint instantiated = Instantiate(_selfPrebab, _startPosition, _startRotation, transform.parent);
            instantiated.SetBreakTime(_timeBeforeBreak);
            instantiated.SetRespawnTime(_timeBeforeRespawn);
            instantiated.Lock();
            Destroy(gameObject);
        }
        #endregion


        #region Private variables
        private bool _shouldFall = false;
        private HingeJoint2D _hingeJoint2D;
        private float _breakTime;
        private float _respawnTime;
        private Vector3 _startPosition;
        private Quaternion _startRotation;
        #endregion
    }
}
