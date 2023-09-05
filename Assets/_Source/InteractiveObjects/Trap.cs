using UnityEngine;

namespace InteractiveObjects
{
    public class Trap : MonoBehaviour
    {
        [SerializeField] private Transform _top;
        [SerializeField] private Transform _bot;
        [SerializeField] private float _speed;

        private bool _isToTop;

        private void Update()
        {
            if (transform.position.y < _top.position.y && _isToTop)
                transform.position += transform.up * _speed * Time.deltaTime;
            else if(transform.position.y > _bot.position.y && !_isToTop)
                transform.position -= transform.up * _speed * Time.deltaTime;

            if (transform.position.y >= _top.position.y)
                _isToTop = !_isToTop;
            else if (transform.position.y <= _bot.position.y)
                _isToTop = !_isToTop;
        }
    }
}