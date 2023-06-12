using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class QualityButtonHandler : MonoBehaviour
{
    [SerializeField] private Color _idleColor, _activeColor;
    
    private Image _image;

    [SerializeField] private int _targetQualityIndex = 0;

    private void Awake() {
        _image = GetComponent<Image>();
        UpdateButtonsState();
    }

    public void UpdateButtonsState() {
        int currentQualityIndex = QualitySettings.GetQualityLevel();
        _image.color = currentQualityIndex == _targetQualityIndex ? _activeColor : _idleColor;
    }
}
