using TMPro;
using UnityEngine;

namespace Core
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _startText;

        public void TurnOffText()
        {
            _startText.gameObject.SetActive(false);
        }
    }
}