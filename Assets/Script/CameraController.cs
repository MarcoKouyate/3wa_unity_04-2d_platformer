using UnityEngine;

namespace Dwarf {
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _smoothTime;
        [SerializeField] private float _offset;

        [Range(0.0f, 1f)]
        [SerializeField] private float _threshold;

        private void Awake()
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            _transform = transform;
            
        }

        private void Update()
        {
            Vector3 targetPosition = _playerTransform.position;
            targetPosition.z = _transform.position.z;

            float horizontalInput = Input.GetAxis("Horizontal") * _offset; 
            if (Mathf.Abs(horizontalInput) >= _threshold)
            {
                targetPosition.x += horizontalInput * _offset;
            }

            _transform.position = Vector3.SmoothDamp(_transform.position, targetPosition, ref _velocity, _smoothTime);


        }

        private Vector3 _velocity = Vector3.zero;
        private Transform _playerTransform;
        private Transform _transform;
    }
}
