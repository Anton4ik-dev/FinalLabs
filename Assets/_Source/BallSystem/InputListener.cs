using Core;
using UnityEngine;
using Zenject;

namespace BallSystem
{
    public class InputListener : MonoBehaviour
    {
        private BallActions _ballActions;
        private Game _game;
        private bool _isStartGame;

        private void Update()
        {
            Move();
            Jump();
            StartGame();
        }

        private void Move()
        {
            _ballActions.Move();
        }

        private void Jump()
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                _ballActions.Jump();
        }

        private void StartGame()
        {
            if (!_isStartGame && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)))
            {
                _game.StartGame();
                _isStartGame = !_isStartGame;
            }
        }

        [Inject]
        public void Construct(BallActions characterActions, Game game)
        {
            _ballActions = characterActions;
            _game = game;
            _game.PauseGame();
        }
    }
}