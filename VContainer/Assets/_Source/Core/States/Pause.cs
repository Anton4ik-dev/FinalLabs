using UnityEngine;

namespace Core
{
    public class Pause : AGameState
    {
        public override void Enter() => Time.timeScale = 0;
        public override void Exit() => Time.timeScale = 1;
    }
}