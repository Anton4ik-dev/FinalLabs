using Core;
using Pool;
using ScoreSystem;
using ScriptableObjects;
using UnityEngine;
using VContainer;

namespace BallSystem
{
    public class BallActions
    {
        private float _moveSpeed;
        private float _jumpStrength;
        private Rigidbody2D _rb;
        private Camera _camera;
        private ScoreView _scoreView;
        private GameStateMachine _gameStateMachine;
        private TilePool _tilePool;

        [Inject]
        public BallActions(BallSO ballSo, Rigidbody2D rb, Camera camera, ScoreView scoreView, GameStateMachine gameStateMachine, TilePool tilePool)
        {
            _moveSpeed = ballSo.MoveSpeed;
            _jumpStrength = ballSo.JumpStrength;
            _rb = rb;
            _camera = camera;
            _scoreView = scoreView;
            _gameStateMachine = gameStateMachine;
            _tilePool = tilePool;
        }

        public void Move()
        {
            Vector3 moveDistance = _rb.transform.right * _moveSpeed * Time.deltaTime;
            _rb.transform.position += moveDistance;
            _camera.transform.position += moveDistance;
        }

        public void Collect(GameObject collision)
        {
            _scoreView.DrawScore();
            collision.SetActive(false);
        }

        public void SpawnTile(GameObject collision)
        {
            _tilePool.GetFreeElement();
            collision.SetActive(false);
        }

        public void Lose()
        {
            _gameStateMachine.ChangeState(typeof(Lose));
        }

        public void Jump()
        {
            _rb.AddForce(Vector3.up * _jumpStrength, ForceMode2D.Impulse);
        }
    }
}