using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class Door : MonoBehaviour
    {
        public bool IsOpen
        {
            get => _isOpen;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _isOpen = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _isOpen = false;
            }
        }


        private SpriteRenderer _spriteRenderer;
        private bool _isOpen;
    }
}
