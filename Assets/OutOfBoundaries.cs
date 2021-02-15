using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class OutOfBoundaries : MonoBehaviour
    {
        [SerializeField] private LevelManager _levelManager;

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _levelManager.Lose();
            }
        }
    }
}
