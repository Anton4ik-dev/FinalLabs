using Core;
using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace BallSystem
{
    public class InputListener : MonoBehaviour
    {
        private BallActions _ballActions;
        private GameStateMachine<Type> _gameStateMachine;
        private bool _isStartGame;

        [Inject]
        public void Construct(BallActions ballActions, IEnumerable<IStateMachine> gameStateMachines)
        {
            _ballActions = ballActions;
            foreach (GameStateMachine<Type> gameStateMachine in gameStateMachines)
            {
                _gameStateMachine = gameStateMachine;
            }
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
                _gameStateMachine.ChangeState(typeof(Game));
                _isStartGame = !_isStartGame;
            }
        }
    }
}