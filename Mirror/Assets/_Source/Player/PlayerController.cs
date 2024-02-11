using LobbySystem;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PlayerSystem
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private NetworkMatch _networkMatch;

        private InputListener _inputListener;
        private MainMenu _mainMenu;
        [SyncVar] private string matchID;

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
            if (isLocalPlayer)
                LocalPlayer = this;
            else
                _mainMenu.SpawnPlayerUIPrefab(this);
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
        private void CmdHostGame(string ID)
        {
            matchID = ID;
            if (_mainMenu.HostGame(ID, this))
            {
                Debug.Log("Лобби было создано успешно");
                _networkMatch.matchId = ID.ToGuid();
                TargetHostGame(true, ID);
            }
            else
            {
                Debug.Log("Ошибка в создании лобби");
                TargetHostGame(false, ID);
            }
        }

        [TargetRpc]
        private void TargetHostGame(bool success, string ID)
        {
            matchID = ID;
            Debug.Log($"ID {matchID} == {ID}");
            _mainMenu.CheckSuccess(success, ID, true);
        }

        [Command]
        private void CmdJoinGame(string ID)
        {
            matchID = ID;
            if (_mainMenu.JoinGame(ID, this))
            {
                Debug.Log("Успешное подключение к лобби");
                _networkMatch.matchId = ID.ToGuid();
                TargetJoinGame(true, ID);
            }
            else
            {
                Debug.Log("Не удалось подключиться");
                TargetJoinGame(false, ID);
            }
        }

        [TargetRpc]
        private void TargetJoinGame(bool success, string ID)
        {
            matchID = ID;
            Debug.Log($"ID {matchID} == {ID}");
            _mainMenu.CheckSuccess(success, ID, false);
        }

        [Command]
        private void CmdBeginGame()
        {
            _mainMenu.BeginGame(matchID);
            Debug.Log("Игра начилась");
        }

        [TargetRpc]
        private void TargetBeginGame()
        {
            Debug.Log($"ID {matchID} | начало");
            DontDestroyOnLoad(gameObject);
            transform.localScale = new Vector3(1,1,1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Move(float horizontal, float vertical)
        {
            transform.Translate(new Vector2(horizontal * _speed * Time.deltaTime,
                vertical * _speed * Time.deltaTime));
        }

        public void HostGame()
        {
            string ID = RandomIdGenerator.GetRandomID();
            CmdHostGame(ID);
        }

        public void StartGame()
        {
            TargetBeginGame();
        }

        public void BeginGame()
        {
            CmdBeginGame();
        }

        public void JoinGame(string inputID)
        {
            CmdJoinGame(inputID);
        }
    }
}