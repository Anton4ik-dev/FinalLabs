using BallSystem;
using Pool;
using ScoreSystem;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private TilePoolSO _tilePoolSo;
        [SerializeField] private BallSO _ballSo;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Camera _camera;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private GameView _gameView;

        public override void InstallBindings()
        {
            Container.Bind<TilePoolSO>().FromInstance(_tilePoolSo).NonLazy();
            Container.Bind<BallSO>().FromInstance(_ballSo).NonLazy();

            Container.Bind<Rigidbody2D>().FromInstance(_rb).NonLazy();
            Container.Bind<Camera>().FromInstance(_camera).NonLazy();

            Container.Bind<ScoreView>().FromInstance(_scoreView).NonLazy();
            Container.Bind<GameView>().FromInstance(_gameView).NonLazy();

            Container.Bind<TilePool>().AsSingle().NonLazy();
            Container.Bind<ScoreController>().AsSingle().NonLazy();
            Container.Bind<BallActions>().AsSingle().NonLazy();
            Container.Bind<Game>().AsSingle().NonLazy();
        }
    }
}