using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class LevelManager : MonoBehaviour
    {
        private void Start()
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            _startPosition = _playerTransform.position;
        }

        public void Lose()
        {
            _playerTransform.position = _startPosition;
        }

        public void Win()
        {
            Debug.Log("Win");
        }

        private Transform _playerTransform;
        private Vector3 _startPosition;
    }
}
