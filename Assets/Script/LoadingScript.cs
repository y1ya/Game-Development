using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public string sceneToLoad;         // Name of the next scene
    public Slider progressBar;         // Optional UI slider for progress
    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        operation.allowSceneActivation = false; // Wait until loading is done

        while (!operation.isDone)
        {
            // Update progress bar (value goes from 0 to 0.9 while loading)
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            if (progressBar != null)
                progressBar.value = progress;

            // When loading reaches 90%, activate the scene
            if (operation.progress >= 0.9f)
            {
                // Optionally wait a second or show "Press any key to continue"
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}

