using Services;
using UnityEngine;
using Zenject;

namespace BallSystem
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private LayerMask _bonusLayer;
        [SerializeField] private LayerMask _tileLayer;

        private BallActions _ballActions;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _ballActions.Lose();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (LayerService.CheckLayersEquality(collision.gameObject.layer, _bonusLayer))
                _ballActions.Collect(collision.gameObject);
            else if (LayerService.CheckLayersEquality(collision.gameObject.layer, _tileLayer))
                _ballActions.SpawnTile(collision.gameObject);
        }

        [Inject]
        public void Construct(BallActions ballActions)
        {
            _ballActions = ballActions;
        }
    }
}