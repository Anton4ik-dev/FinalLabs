using DG.Tweening;
using UnityEngine;

namespace InteractiveObjects
{
    public class Trap : MonoBehaviour
    {
        [SerializeField] private Transform _top;
        [SerializeField] private Transform _bot;
        [SerializeField] private float _duration;

        private void Awake()
        {
            MoveToTop();
        }

        private void MoveToTop()
        {
            Tween tween = transform.DOMoveY(_top.position.y, _duration);
            tween.OnComplete(MoveToBot);
        }

        private void MoveToBot()
        {
            Tween tween = transform.DOMoveY(_bot.position.y, _duration);
            tween.OnComplete(MoveToTop);
        }
    }
}