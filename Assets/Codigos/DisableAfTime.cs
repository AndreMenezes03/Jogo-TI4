using UnityEngine;

namespace Codigos
{
    public class DisableAfTime : MonoBehaviour
    {
        [SerializeField] private float timeDis = 0.3f;

        private float _timer;

        private void OnEnable()
        {
            _timer = timeDis;

        }

        private void LateUpdate()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                gameObject.SetActive(false);
            }

        }

    }
}
