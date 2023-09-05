using UnityEngine.SceneManagement;

namespace Game
{
    public class GameController
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}