using System;
using System.Collections.Generic;
using VContainer;

namespace Core
{
    public class GameStateMachine<T> : IStateMachine where T : Type
    {
        private Dictionary<T, AStateGame> _states;
        private AStateGame _activeState;

        [Inject]
        public GameStateMachine(IEnumerable<AStateGame> states)
        {
            _states = new Dictionary<T, AStateGame>();
            foreach(AStateGame state in states)
            {
                _states.Add((T)state.GetType(), state);
            }
        }

        public void ChangeState(Type type)
        {
            _activeState.Exit();
            StartState((T)type);
        }

        public void StartState(Type type)
        {
            _activeState = _states[(T)type];
            _activeState.Enter();
        }
    }
}