using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    public class StickToPlatform : MonoBehaviour
    {
        [SerializeField] private GroundChecker _groundChecker;

        private void Update()
        {
            Collider2D collider = _groundChecker.GetGround();
            if (collider != _currentCollider)
            {
                if (collider != null && collider.CompareTag("Platform"))
                {
                    transform.SetParent(collider.transform);
                }
                else if(transform.parent != null && transform.parent.CompareTag("Platform"))
                {
                    transform.SetParent(null);
                }
            }
            _currentCollider = collider;
        }

        private Collider2D _currentCollider = null;
    }
}
