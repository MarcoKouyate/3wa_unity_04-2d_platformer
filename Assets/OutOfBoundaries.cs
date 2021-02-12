using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class OutOfBoundaries : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("You died");
            }
        }
    }
}
