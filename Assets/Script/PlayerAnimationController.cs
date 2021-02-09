using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf {
    [RequireComponent(typeof(Animator))] 
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private float runningSpeed;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void IsGrounded(bool value)
        {
            _animator.SetBool("isGrounded", value);
        }

        public void Jump()
        {
            _animator.SetTrigger("jump");
        }

        public void Walk()
        {
            _animator.SetInteger("speed", 1);
        }

        public void Run()
        {
            _animator.SetInteger("speed", 2);
        }

        public void Stand()
        {
            _animator.SetInteger("speed", 0);
        }

        public void SetVerticalSpeed(float value)
        {
            _animator.SetFloat("verticalSpeed", value);
        }

        public void SetHorizontalSpeed(float value)
        {
            float speed = Mathf.Abs(value);

            if (speed > runningSpeed)
            {
                Run();
            } else if (speed > 0)
            {
                Walk();
            } else
            {
                Stand();
            }
        }

        private Animator _animator;
    }
}
