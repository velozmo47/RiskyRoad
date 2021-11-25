using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    [Header("Dependencies")]
    public LoadingScreenUI loadingScreenUI;
    bool dependenciesLoaded;

    private LoadSceneRequest _pendingRequest;

    public void OnLoadMenuRequest(LoadSceneRequest request)
    {
        if (IsSceneAlreadyLoaded(request.scene) == false)
        {
            // Menus are loaded instantly
            SceneManager.LoadScene(request.scene.name);
        }
    }

    // Function that will be called from a listener
    public void OnLoadLevelRequest(LoadSceneRequest request)
    {
        if (IsSceneAlreadyLoaded(request.scene))
        {
            // Level is already loaded. Activate it
            ActivateLevel(request);
        }
        else
        {
            // Level is not loaded
            if (request.loadingScreen)
            {
                // If a loading screen is requested, the show it and wait
                this._pendingRequest = request;
                this.loadingScreenUI.ToggleScreen(true);
            }
            else
            {
                // If no loading screen requested, load it ASAP
                StartCoroutine(ProcessLevelLoading(request));
            }
        }
    }

    // Function that will be called from a listener
    public void OnLoadingScreenToggled(bool enabled)
    {
        if (enabled && this._pendingRequest != null)
        {
            // When loading screen is shown, we receibe the event and can load the new level
            StartCoroutine(ProcessLevelLoading(this._pendingRequest));
        }
    }

    public void ToggleDependenciesLoaded(bool status)
    {
        this.dependenciesLoaded = status;
    }

    private bool IsSceneAlreadyLoaded(SceneSO scene)
    {
        Scene loadedScene = SceneManager.GetSceneByName(scene.name);

        if (loadedScene != null && loadedScene.isLoaded == true)
            return true;
        else
            return false;
    }

    private IEnumerator ProcessLevelLoading(LoadSceneRequest request)
    {
        if (request.scene != null)
        {
            var currentLoadedLevel = SceneManager.GetActiveScene();
            SceneManager.UnloadSceneAsync(currentLoadedLevel);

            AsyncOperation loadSceneProcess = SceneManager.LoadSceneAsync(request.scene.name, LoadSceneMode.Additive);

            // Level is being loaded, it could take some seconds (or not). Waiting until is fully loaded
            while (!loadSceneProcess.isDone)
            {
                yield return null;
            }

            // Once the level is ready, activate it!
            ActivateLevel(request);
        }
    }

    private void ActivateLevel(LoadSceneRequest request)
    {
        var loadedLevel = SceneManager.GetSceneByName(request.scene.name);
        SceneManager.SetActiveScene(loadedLevel);

        if (request.loadingScreen)
        {
            this.loadingScreenUI.ToggleScreen(false);
            // StartCoroutine(ToggleScreenOnDependenciesLoaded(false));
        }

        // Clean status
        this._pendingRequest = null;
    }

    private IEnumerator ToggleScreenOnDependenciesLoaded (bool enable)
    {
        while (dependenciesLoaded == false)
        {
            yield return null;
        }

        dependenciesLoaded = false;
        this.loadingScreenUI.ToggleScreen(enable);
    }
}
