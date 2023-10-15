using Core;
using UnityEngine;
using VContainer;

namespace BallSystem
{
    public class InputListener : MonoBehaviour
    {
        private BallActions _ballActions;
        private IStateMachine _gameStateMachine;
        private bool _isStartGame;

        [Inject]
        public void Construct(BallActions ballActions, IStateMachine gameStateMachine)
        {
            _ballActions = ballActions;
            _gameStateMachine = gameStateMachine;
        }

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
                _gameStateMachine.ChangeState<Game>();
                _isStartGame = !_isStartGame;
            }
        }
    }
}