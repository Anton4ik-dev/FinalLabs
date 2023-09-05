using Game;
using Pool;
using ScoreSystem;
using UnityEngine;

namespace BallSystem
{
    public class BallActions
    {
        private float _moveSpeed;
        private float _jumpStrength;
        private Rigidbody2D _rb;
        private Camera _camera;

        public BallActions(float moveSpeed, float jumpStrength, Rigidbody2D rb, Camera camera)
        {
            _moveSpeed = moveSpeed;
            _jumpStrength = jumpStrength;
            _rb = rb;
            _camera = camera;
        }

        public void Move()
        {
            Vector3 moveDistance = _rb.transform.right * _moveSpeed * Time.deltaTime;
            _rb.transform.position += moveDistance;
            _camera.transform.position += moveDistance;
        }

        public void Collect(ScoreView scoreView, GameObject collision)
        {
            scoreView.AddScore();
            collision.SetActive(false);
        }

        public void SpawnTile(TilePool tilePool, GameObject collision)
        {
            tilePool.GetFreeElement();
            collision.SetActive(false);
        }

        public void Lose(GameController gameController)
        {
            gameController.RestartGame();
        }

        public void Jump()
        {
            _rb.AddForce(Vector3.up * _jumpStrength, ForceMode2D.Impulse);
        }
    }
}