using UnityEngine;
using static UnityEngine.Vector2;

namespace Codigos
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        private Rigidbody2D _rgd2d;

        public Vector3 moVector;

        public float lastHorizontal;
        public float lastVertical;

        [SerializeField] private float speed = 3f;

        private Animate _animate;

        private void Awake()
        {
            _rgd2d = GetComponent<Rigidbody2D>();
            moVector = new Vector3();
            _animate = GetComponent<Animate>();
            lastHorizontal = 0.1f;
        }

        private void Update()
        {
            if(moVector.x != 0)
            {
                lastHorizontal = moVector.x;
            }
            if(moVector.y != 0)
            {
                lastVertical = moVector.y;
            }
            var movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            moVector.x = movement.x;
            moVector.y = movement.y;
            var isMoving = movement != zero;


            _rgd2d.velocity = movement * speed;

            _animate.Moving = isMoving;
            _animate.horizontal = movement.x;
            _animate.vertical = movement.y;

            moVector *= speed;

            _rgd2d.velocity = moVector;
        }
    }
}
