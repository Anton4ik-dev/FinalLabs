using System;
using System.Collections.Generic;
using VContainer;

namespace Core
{
    public class GameStateMachine
    {
        private Dictionary<Type, AStateGame> _states;
        private AStateGame _activeState;

        [Inject]
        public GameStateMachine(IEnumerable<AStateGame> states)
        {
            _states = new Dictionary<Type, AStateGame>();
            foreach(AStateGame state in states)
            {
                _states.Add(state.GetType(), state);
            }
        }

        public void ChangeState(Type type)
        {
            _activeState.Exit();
            StartState(type);
        }

        public void StartState(Type type)
        {
            _activeState = _states[type];
            _activeState.Enter();
        }
    }
}