using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameController
    {
        private TextMeshProUGUI _startText;

        public GameController(TextMeshProUGUI startText)
        {
            _startText = startText;
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void StartGame()
        {
            Time.timeScale = 1;
            _startText.gameObject.SetActive(false);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}