using UnityEngine;

namespace Dwarf {
    public class CollectableCollider : MonoBehaviour
    {
        [SerializeField] private IntVariable _count;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _count.count++;
                Destroy(gameObject);
            }
        }
    }
}
