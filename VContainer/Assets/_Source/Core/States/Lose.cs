using UnityEngine.SceneManagement;

namespace Core
{
    public class Lose : AStateGame
    {
        public override void Enter() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}