namespace Core
{
    public abstract class AGameState
    {
        public virtual void Enter() { }
        public virtual void Exit() { }
    }
}