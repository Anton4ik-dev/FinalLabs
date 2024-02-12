using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class YGAdsProvider : MonoBehaviour
{
    [SerializeField] private Button _showAdButton;

    [DllImport("__Internal")]
    private static extern void ShowFullscreen();

    private void Awake()
    {
        Bind();
    }

    private void OnDestroy()
    {
        Expose();
    }

    private void Bind()
    {
        _showAdButton.onClick.AddListener(ShowFullscreen);
    }

    private void Expose()
    {
        _showAdButton.onClick.RemoveListener(ShowFullscreen);
    }
}