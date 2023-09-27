using System;
using System.Collections.Generic;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class Bootstrapper : IStartable
    {
        private GameStateMachine<Type> _gameStateMachine;

        [Inject]
        public void Construct(IEnumerable<IStateMachine> gameStateMachines)
        {
            foreach (GameStateMachine<Type> gameStateMachine in gameStateMachines)
            {
                _gameStateMachine = gameStateMachine;
            }
        }

        void IStartable.Start()
        {
            _gameStateMachine.StartState(typeof(Pause));
        }
    }
}