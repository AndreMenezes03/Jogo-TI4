using UnityEngine;

namespace Codigos
{
    public class Character : MonoBehaviour
    {
        public int maxHp = 100;

        public int curHp = 100;

        public void TakeDamage(int dano)
        {
            curHp -= dano;

            if (curHp <= 0)
            {
                Die();
            }
        }

        private static void Die()
        {
            Debug.Log("Morto");
            throw new System.NotImplementedException();
        }
    }
}