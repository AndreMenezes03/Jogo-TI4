using UnityEngine;

namespace Codigos
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform targetDestination;
        private GameObject _tarGameObject;
        private Character _targChar;
        private const int Dmg = 1;
        [SerializeField] float speed = 2f;
        private Rigidbody2D _rgdEnmy;
        [SerializeField] private int hp = 6;

        private void FixedUpdate()
        {
            Vector3 direction = (targetDestination.position - transform.position).normalized;
            _rgdEnmy.velocity = direction * speed;
        }

        private void Awake()
        {
            _rgdEnmy = GetComponent<Rigidbody2D>();
            _tarGameObject = targetDestination.gameObject;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject == _tarGameObject) {
                Attack();
            }
        }

        private void Attack()
        {
            _targChar ??= targetDestination.GetComponent<Character>();
            _targChar.TakeDamage(Dmg);
        }

        public void TakeDamage(int damg)
        {
            hp -= damg;
            if(hp <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
