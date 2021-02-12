using UnityEngine;

namespace Dwarf {
    [RequireComponent(typeof(Rigidbody2D))]
    public class MobilePlatform : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _threshold;
        [SerializeField] private Transform[] _targets;


        private void Awake()
        {
            if (_targets.Length > 0)
            {
                transform.position = _targets[0].position;
            }
        }

        private void FixedUpdate()
        {
            if(_targets.Length > 0)
            {
                MovePlatform();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;

            for (int i = 0; i < _targets.Length - 1; i++)
            {
                Gizmos.DrawLine(_targets[i].position, _targets[i + 1].position);
                Gizmos.DrawSphere(_targets[i].position, 0.1f);
            }
            
            Gizmos.DrawSphere(transform.position, 0.2f);
           
            if(_targets.Length > 0)
            {
                Gizmos.DrawSphere(_targets[_targets.Length - 1].position, 0.1f);
            }
        }


        private void MovePlatform()
        {
            Vector2 direction = (_targetPosition - (Vector2)transform.position);
            transform.position = (Vector2)transform.position + direction.normalized * Time.fixedDeltaTime * _speed;

            if (direction.sqrMagnitude <= _threshold * _threshold)
            {
                _targetPosition = GetNextTarget().position;
            }
        }

        private Transform GetNextTarget()
        {
            _index += (_changeDirection) ? -1 : +1;

            if (_index <= 0 || _index >= _targets.Length - 1)
            {
                _changeDirection = !_changeDirection;
            }

            return _targets[_index];
        }

        public bool _changeDirection;
        private Vector2 _targetPosition;
        private int _index;
    }
}
