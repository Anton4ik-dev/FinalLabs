using UnityEngine.SceneManagement;

namespace Core
{
    public class Lose : AGameState
    {
        public override void Enter() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}