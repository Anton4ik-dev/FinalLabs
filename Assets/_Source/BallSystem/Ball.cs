using Game;
using Pool;
using ScoreSystem;
using Services;
using UnityEngine;
using Zenject;

namespace BallSystem
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpStrength;

        [SerializeField] private InputListener _inputListener;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Camera _camera;

        [SerializeField] private LayerMask _bonusLayer;
        [SerializeField] private LayerMask _tileLayer;

        private BallActions _ballActions;
        private GameController _gameController;
        private TilePool _tilePool;
        private LayerService _layerService;

        [Inject]
        public void Initialize(GameController gameController, LayerService layerService, TilePool tilePool)
        {
            _gameController = gameController;
            _layerService = layerService;
            _tilePool = tilePool;
            _ballActions = new BallActions(_moveSpeed, _jumpStrength, _rb, _camera);
            _inputListener.Initialize(_ballActions, _gameController);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _ballActions.Lose(_gameController);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_layerService.CheckLayersEquality(collision.gameObject.layer, _bonusLayer))
                _ballActions.Collect(_scoreView, collision.gameObject);
            else if (_layerService.CheckLayersEquality(collision.gameObject.layer, _tileLayer))
                _ballActions.SpawnTile(_tilePool, collision.gameObject);
        }
    }
}