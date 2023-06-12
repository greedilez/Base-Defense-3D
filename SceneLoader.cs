using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    private int _targetSceneToLoad = 1;

    public void UpdateTargetSceneToLoad(int targetScene) => _targetSceneToLoad = targetScene;

    public void LoadSceneAfter(float seconds) => StartCoroutine(SceneLoadDelay(seconds));
    
    public IEnumerator SceneLoadDelay(float seconds) {
        yield return new WaitForSeconds(seconds); LoadScene(_targetSceneToLoad);
    }

    public void LoadScene(int index) => SceneManager.LoadScene(index);
}
