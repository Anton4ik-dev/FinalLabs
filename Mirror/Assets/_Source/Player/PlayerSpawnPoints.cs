using UnityEngine;

namespace PlayerSystem
{
    public class PlayerSpawnPoints : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}