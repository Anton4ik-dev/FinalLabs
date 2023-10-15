using BallSystem;
using TileSystem;
using ScoreSystem;
using ScriptableObjects;
using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class GameLifeTimeScope : LifetimeScope
    {
        [SerializeField] private TilePoolSO _tilePoolSo;
        [SerializeField] private BallSO _ballSo;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Camera _camera;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private GameView _gameView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_tilePoolSo);
            builder.RegisterComponent(_ballSo);
            builder.RegisterComponent(_rb);
            builder.RegisterComponent(_camera);
            builder.RegisterComponent(_scoreView);
            builder.RegisterComponent(_gameView);

            builder.Register<AGameState, Game>(Lifetime.Scoped);
            builder.Register<AGameState, Pause>(Lifetime.Scoped);
            builder.Register<AGameState, Lose>(Lifetime.Scoped);

            builder.Register<IStateMachine, GameStateMachine<AGameState>>(Lifetime.Scoped);
            builder.Register<IPool, TilePool<MonoBehaviour>>(Lifetime.Scoped);

            builder.Register<ScoreController>(Lifetime.Singleton);
            builder.Register<BallActions>(Lifetime.Singleton);

            builder.RegisterEntryPoint<Bootstrapper>();
        }
    }
}