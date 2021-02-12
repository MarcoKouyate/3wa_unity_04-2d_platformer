using UnityEngine;

namespace Dwarf {
    [RequireComponent(typeof(Rigidbody2D))]
    public class MobilePlatform : MonoBehaviour
    {
        [SerializeField] private Transform _startTransform;
        [SerializeField] private Transform _endTransform;
        [SerializeField] private float _speed;
        [SerializeField] private float _threshold;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            transform.position = _startTransform.position;
        }

        private void Update()
        {
            _targetPosition = (_changeDirection) ? _startTransform.position : _endTransform.position;
        }

        private void FixedUpdate()
        {
            Vector2 direction = (_targetPosition - (Vector2)_rigidbody.position);
            Vector2 newPosition = _rigidbody.position + direction.normalized * Time.fixedDeltaTime * _speed;
            _rigidbody.MovePosition(newPosition);

            if (direction.sqrMagnitude <= _threshold * _threshold)
            {
                _changeDirection = !_changeDirection;
            }
        }

        public bool _changeDirection;
        private Rigidbody2D _rigidbody;
        private Vector2 _targetPosition;
    }
}
