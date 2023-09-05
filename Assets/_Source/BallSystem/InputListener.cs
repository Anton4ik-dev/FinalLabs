using UnityEngine;

namespace BallSystem
{
    public class InputListener : MonoBehaviour
    {
        private BallActions _ballActions;

        private void Update()
        {
            _ballActions.Move();

            if(Input.GetKey(KeyCode.Space))
                _ballActions.Jump();
        }

        public void Initialize(BallActions characterActions)
        {
            _ballActions = characterActions;
        }
    }
}