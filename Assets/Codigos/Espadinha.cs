using System.Collections.Generic;
using UnityEngine;

namespace Codigos
{
    public class Espadinha : MonoBehaviour
    {
        private const float TimeToAttack = 2f;
        private float _timer;
        [SerializeField] private GameObject leftEspada;
        [SerializeField] private GameObject rightEspada;
        private PlayerMove _playerMove;
        [SerializeField] private Vector2 espadaSize = new Vector2(6f, 6f);
        [SerializeField] private int espadaDano = 2;

        private readonly List<Enemy> _enemies = new List<Enemy>();

        private void Awake()
        {
            _playerMove = FindObjectOfType<PlayerMove>();
            CacheEnemyComponents();
        }

        private void CacheEnemyComponents()
        {
            var enemyObjects = FindObjectsOfType<Enemy>();
            foreach (var enemy in enemyObjects)
            {
                _enemies.Add(enemy);
            }
        }

        private void Update()
        {
            if (_playerMove is null) return;

            _timer -= Time.deltaTime;
            if (_timer < 0f)
            {
                Attack();
                _timer = TimeToAttack;
            }
        }

        private void Attack()
        {
            if (_playerMove is null) return;

            Collider2D[] colliders;
            switch (_playerMove.lastHorizontal.CompareTo(0))
            {
                case > 0:
                    rightEspada.SetActive(true);
                    colliders = Physics2D.OverlapBoxAll(rightEspada.transform.position, espadaSize, 0);
                    ApplyDamage(colliders);
                    break;
                case < 0:
                    leftEspada.SetActive(true);
                    colliders = Physics2D.OverlapBoxAll(leftEspada.transform.position, espadaSize, 0);
                    ApplyDamage(colliders);
                    break;
            }
        }

        private void ApplyDamage(IEnumerable<Collider2D> colliders)
        {
            foreach (var col in colliders)
            {
                var enemy = _enemies.Find(e => e.gameObject == col.gameObject);
                enemy?.TakeDamage(espadaDano);
            }
        }
    }
}
