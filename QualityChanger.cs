using UnityEngine;

public class QualityChanger : MonoBehaviour
{
    public void ChangeQualityLevel(int targetQualityIndex) {
        QualitySettings.SetQualityLevel(targetQualityIndex);
    }
}
