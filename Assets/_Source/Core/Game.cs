using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Game
    {
        private GameView _gameView;

        public Game(GameView gameView)
        {
            _gameView = gameView;
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void StartGame()
        {
            Time.timeScale = 1;
            _gameView.TurnOffText();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}