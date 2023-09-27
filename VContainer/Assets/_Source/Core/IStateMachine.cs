using System;

namespace Core
{
    public interface IStateMachine
    {
        public void ChangeState(Type type);
    }
}
