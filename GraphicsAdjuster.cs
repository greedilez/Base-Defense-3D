using UnityEngine;
using UnityEngine.Rendering;

public class GraphicsAdjuster : MonoBehaviour
{
    private void Awake() => SetupGameGraphics();

    private void SetupGameGraphics() {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        QualitySettings.vSyncCount = 0;
        GraphicsSettings.useScriptableRenderPipelineBatching = true;
    }
}
