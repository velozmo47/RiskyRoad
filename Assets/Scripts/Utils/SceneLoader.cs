using UnityEngine;
using ScriptableObjectArchitecture;

public class SceneLoader : MonoBehaviour
{
    [Header("Configuration")]
    public SceneSO sceneToLoad;
    public bool loadingScreen;

    [Header("Broadcasting events")]
    public LoadSceneRequestGameEvent loadSceneEvent;

    public void LoadScene()
    {
        var request = new LoadSceneRequest(
            scene: this.sceneToLoad,
            loadingScreen: this.loadingScreen
        );

        this.loadSceneEvent.Raise(request);
    }
}
