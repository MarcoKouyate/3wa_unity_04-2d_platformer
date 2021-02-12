using UnityEngine;

namespace Dwarf {
    [ExecuteInEditMode]
    public class ColliderFitSprite : MonoBehaviour
    {
        void Awake()
        {
            runInEditMode = true;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<BoxCollider2D>();
        }

        void Update()
        { 
            _collider.offset = new Vector2(0, 0);
            _collider.size = new Vector3(_spriteRenderer.bounds.size.x / transform.lossyScale.x,
                                         _spriteRenderer.bounds.size.y / transform.lossyScale.y,
                                         _spriteRenderer.bounds.size.z / transform.lossyScale.z);
        }

        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _collider;
    }
}
