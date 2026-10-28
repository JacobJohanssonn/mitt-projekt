using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        string SceneToLoad = PlayerPrefs.GetString("SceneToLoad");

        AsyncOperation Operation =
            SceneManager.LoadSceneAsync(SceneToLoad);

        while (!Operation.isDone)
        {
            float Progress = Mathf.Clamp01(Operation.progress / 0.9f);

            Debug.Log("Progress");

            yield return null;
        }
    }
}
