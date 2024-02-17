using UnityEngine;
using Mirror;
using UnityEngine.UI;
using PlayerSystem;
using TMPro;

namespace LobbySystem
{
    public class MainMenu : NetworkBehaviour
    {
        [SerializeField] private Canvas _lobbyCanvas;
        [SerializeField] private Button _hostButton;
        [SerializeField] private Button _joinButton;
        [SerializeField] private Button _beginGameButton;
        [SerializeField] private TMP_InputField _joinInput;
        [SerializeField] private TMP_InputField _nameInput;
        [SerializeField] private TextMeshProUGUI _idText;
        
        [SerializeField] private PlayerData _playerDataPrefab;
        [SerializeField] private Lobby _lobbyPrefab;

        [SerializeField] private Transform _playerDataHolder;

        private readonly SyncList<Match> _matches = new SyncList<Match>();
        private readonly SyncList<string> _matchIDs = new SyncList<string>();

        private void Start()
        {
            Bind();
        }

        private void OnDestroy()
        {
            Expose();
        }

        private void Bind()
        {
            _hostButton.onClick.AddListener(Host);
            _joinButton.onClick.AddListener(Join);
            _beginGameButton.onClick.AddListener(StartGame);
        }

        private void Expose()
        {
            _hostButton.onClick.RemoveListener(Host);
            _joinButton.onClick.RemoveListener(Join);
            _beginGameButton.onClick.RemoveListener(StartGame);
        }

        private void ChangeButtonsState(bool isOn)
        {
            _joinInput.interactable = isOn;
            _hostButton.interactable = isOn;
            _joinButton.interactable = isOn;
        }

        private void Host()
        {
            ChangeButtonsState(false);
            PlayerController.LocalPlayer.HostGame(_nameInput.text);
        }

        private void Join()
        {
            ChangeButtonsState(false);
            PlayerController.LocalPlayer.JoinGame(_joinInput.text.ToUpper(), _nameInput.text);
        }

        private void StartGame()
        {
            PlayerController.LocalPlayer.BeginGame();
        }

        public void CheckSuccess(bool success, string matchID, bool isHost)
        {
            if (success)
            {
                _lobbyCanvas.enabled = true;
                SpawnPlayerPrefab(PlayerController.LocalPlayer);
                _idText.text = matchID;
                _beginGameButton.interactable = isHost;
            }
            else
            {
                ChangeButtonsState(true);
            }
        }

        public bool HostGame(string matchID, PlayerController player)
        {
            if (!_matchIDs.Contains(matchID))
            {
                _matchIDs.Add(matchID);
                _matches.Add(new Match(matchID, player));
                return true;
            }
            return false;
        }

        public bool JoinGame(string matchID, PlayerController player)
        {
            if (_matchIDs.Contains(matchID))
            {
                for (int i = 0; i < _matches.Count; i++)
                {
                    if (_matches[i].ID == matchID)
                    {
                        _matches[i].Players.Add(player);
                        break;
                    }
                }

                return true;
            }
            return false;
        }

        public void SpawnPlayerPrefab(PlayerController player)
        {
            PlayerData newPlayer = Instantiate(_playerDataPrefab, _playerDataHolder);
            newPlayer.SetPlayer(player);
        }

        public void BeginGame(string matchID)
        {
            Lobby newLobby = Instantiate(_lobbyPrefab);
            NetworkServer.Spawn(newLobby.gameObject);
            newLobby.NetworkMatch.matchId = matchID.ToGuid();

            for (int i = 0; i < _matches.Count; i++)
            {
                if (_matches[i].ID == matchID)
                {
                    foreach (PlayerController player in _matches[i].Players)
                    {
                        newLobby.AddPlayer(player);
                        player.StartGame();
                    }
                    break;
                }
            }
        }
    }
}