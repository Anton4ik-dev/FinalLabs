using TMPro;
using UnityEngine;
using VContainer;

namespace Core
{
    public class Game : AStateGame
    {
        [SerializeField] private GameView _gameView;

        [Inject]
        public Game(GameView gameView)
        {
            _gameView = gameView;
        }

        public override void Enter()
        {
            Time.timeScale = 1;
            _gameView.TurnOffText();
        }
        public override void Exit() => Time.timeScale = 0;
    }
}