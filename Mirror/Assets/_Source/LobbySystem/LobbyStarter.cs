using UnityEngine;

namespace LobbySystem
{
    public class LobbyStarter : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _spawnPoints;
        [SerializeField] private GameObject _inputListener;

        private void Awake()
        {
            _mainMenu.SetActive(true);
            _spawnPoints.SetActive(true);
            _inputListener.SetActive(true);

            DontDestroyOnLoad(_spawnPoints);
            DontDestroyOnLoad(_inputListener);
        }
    }
}