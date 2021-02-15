using UnityEngine;
using TMPro;

namespace Dwarf {
    [RequireComponent(typeof(TMP_Text))]
    public class DisplayCollectableCount : MonoBehaviour
    {
        [SerializeField] private IntVariable _collectable;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _text.text = $"{_collectable.count}";
        }

        private TMP_Text _text;
    }
}
