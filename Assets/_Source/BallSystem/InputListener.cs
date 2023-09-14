using Core;
using UnityEngine;
using VContainer;

namespace BallSystem
{
    public class InputListener : MonoBehaviour
    {
        private BallActions _ballActions;
        private GameStateMachine _gameStateMachine;
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
                _gameStateMachine.ChangeState(typeof(Game));
                _isStartGame = !_isStartGame;
            }
        }

        [Inject]
        public void Construct(BallActions ballActions, GameStateMachine gameStateMachine)
        {
            _ballActions = ballActions;
            _gameStateMachine = gameStateMachine;
            _gameStateMachine.StartState(typeof(Pause));
        }
    }
}