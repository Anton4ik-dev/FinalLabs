using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BallSO", menuName = "SO/Ball", order = 0)]
    public class BallSO : ScriptableObject
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpStrength;

        public float MoveSpeed { get => _moveSpeed; private set { } }
        public float JumpStrength { get => _jumpStrength; private set { } }
    }
}