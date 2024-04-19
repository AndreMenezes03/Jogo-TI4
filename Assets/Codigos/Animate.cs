using UnityEngine;

namespace Codigos
{
    public class Animate : MonoBehaviour
    {
        private Animator _animator;

        public float horizontal;
        public float vertical;
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int MovingProp = Animator.StringToHash("Moving");

        public bool Moving { get; internal set; }

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        private void Update()
        {
            _animator.SetFloat(Horizontal, horizontal);
            _animator.SetFloat(Vertical, vertical);
            _animator.SetBool(MovingProp, Moving);
        }
    }
}
