using UnityEngine;

namespace LobbySystem
{
    public class LobbyStarter : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu;

        private void Start()
        {
            _mainMenu.SetActive(true);
        }
    }
}