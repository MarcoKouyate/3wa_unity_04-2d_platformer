using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Door))]
    public class DoorAnimation : MonoBehaviour
    {
        [SerializeField] private Sprite _closedDoor;
        [SerializeField] private Sprite _openDoor;


        private void Awake()
        {
            _door = GetComponent<Door>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            _spriteRenderer.sprite = (_door.IsOpen) ? _openDoor : _closedDoor;
        }

        private SpriteRenderer _spriteRenderer;
        private Door _door;
    }
}
