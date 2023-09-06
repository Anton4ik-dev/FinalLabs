using Game;
using UnityEngine;

namespace BallSystem
{
    public class InputListener : MonoBehaviour
    {
        private BallActions _ballActions;
        private GameController _gameController;
        private bool _isStartGame;

        private void Update()
        {
            _ballActions.Move();

            if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                _ballActions.Jump();

            if(Input.GetKeyDown(KeyCode.Space) && !_isStartGame)
            {
                _gameController.StartGame();
                _isStartGame = !_isStartGame;
            }
        }

        public void Initialize(BallActions characterActions, GameController gameController)
        {
            _ballActions = characterActions;
            _gameController = gameController;
            _gameController.PauseGame();
        }
    }
}