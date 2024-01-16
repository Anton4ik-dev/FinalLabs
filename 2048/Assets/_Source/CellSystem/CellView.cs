using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CellSystem
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _numberText;
        [SerializeField] private float _moveDuration;

        public void ChangeValue(int value)
        {
            _numberText.text = $"{value}";
        }

        public void Move(int x, int y)
        {
            transform.DOMove(new Vector2(x, -y), _moveDuration);
        }
    }
}