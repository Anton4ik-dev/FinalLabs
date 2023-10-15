using System;
using System.Collections.Generic;
using VContainer;

namespace Core
{
    public class GameStateMachine<T> : IStateMachine where T : AGameState
    {
        private Dictionary<Type, T> _states;
        private AGameState _activeState;

        [Inject]
        public GameStateMachine(IEnumerable<AGameState> states)
        {
            _states = new Dictionary<Type, T>();
            foreach (AGameState state in states)
            {
                _states.Add(state.GetType(), (T)state);
            }
        }

        public void ChangeState<T>() where T : AGameState
        {
            if (!_states.ContainsKey(typeof(T)))
                return;

            _activeState?.Exit();
            _activeState = _states[typeof(T)];
            _activeState.Enter();
        }
    }
}