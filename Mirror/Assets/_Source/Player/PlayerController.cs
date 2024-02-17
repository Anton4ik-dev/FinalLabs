using LobbySystem;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PlayerSystem
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private NetworkMatch _networkMatch;
        [SerializeField] private TextMeshProUGUI _nameText;

        private InputListener _inputListener;
        private MainMenu _mainMenu;

        [SyncVar] private string _matchID;
        [SyncVar] private string _name;

        public static PlayerController LocalPlayer;

        [Inject]
        public void Construct(InputListener inputListener, MainMenu mainMenu)
        {
            _inputListener = inputListener;
            _mainMenu = mainMenu;
            Bind();
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            transform.localScale = new Vector3(1, 1, 1);
            if (isLocalPlayer)
                LocalPlayer = this;
            else
                _mainMenu.SpawnPlayerPrefab(this);
        }

        private void OnDestroy()
        {
            Expose();
        }

        private void Bind()
        {
            _inputListener.AddListener(this);
        }

        private void Expose()
        {
            _inputListener.RemoveListener(this);
        }

        [Command]
        private void CmdHostGame(string ID, string name)
        {
            _matchID = ID;
            _name = name;
            _nameText.text = name;

            if (_mainMenu.HostGame(ID, this))
            {
                _networkMatch.matchId = ID.ToGuid();
                TargetHostGame(true, ID, name);
            }
            else
            {
                TargetHostGame(false, ID, name);
            }
        }

        [TargetRpc]
        private void TargetHostGame(bool success, string ID, string name)
        {
            _matchID = ID;
            _name = name;
            _nameText.text = name;

            _mainMenu.CheckSuccess(success, ID, true);
        }

        [Command]
        private void CmdJoinGame(string ID, string name)
        {
            _matchID = ID;
            _name = name;
            _nameText.text = name;

            if (_mainMenu.JoinGame(ID, this))
            {
                _networkMatch.matchId = ID.ToGuid();
                TargetJoinGame(true, ID, name);
            }
            else
            {
                TargetJoinGame(false, ID, name);
            }
        }

        [TargetRpc]
        private void TargetJoinGame(bool success, string ID, string name)
        {
            _matchID = ID;
            _name = name;
            _nameText.text = _name;
            _mainMenu.CheckSuccess(success, ID, false);
        }

        [Command]
        private void CmdBeginGame()
        {
            _mainMenu.BeginGame(_matchID);
        }

        [TargetRpc]
        private void TargetBeginGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Move(float horizontal, float vertical)
        {
            transform.Translate(new Vector2(horizontal * _speed * Time.deltaTime,
                vertical * _speed * Time.deltaTime));
        }

        public void HostGame(string name)
        {
            string ID = RandomIdGenerator.GetRandomID();
            CmdHostGame(ID, name);
        }

        public void StartGame()
        {
            TargetBeginGame();
        }

        public void BeginGame()
        {
            CmdBeginGame();
        }

        public void JoinGame(string inputID, string name)
        {
            CmdJoinGame(inputID, name);
        }

        public string GetName() => _name;
    }
}