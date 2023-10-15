using VContainer;
using VContainer.Unity;

namespace Core
{
    public class Bootstrapper : IStartable
    {
        private IStateMachine _gameStateMachine;

        [Inject]
        public void Construct(IStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        void IStartable.Start()
        {
            _gameStateMachine.ChangeState<Pause>();
        }
    }
}