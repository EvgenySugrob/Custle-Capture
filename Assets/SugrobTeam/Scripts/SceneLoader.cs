using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OnStartGame(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Показать окно загрузки
        //loadingScreen.RemoveFromClassList("hidden");

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            // Обновить прогресс-бар
            //if (progressBar != null)
            //    progressBar.value = progress;

            if (operation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(0.5f);
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
        //public void LoadScene(string sceneName)
        //{
        //    //SceneManager.LoadScene(sceneName);
        //    //StartCoroutine(LoadSceneAsync(sceneName));
        //}

        //private IEnumerator LoadSceneAsync(string sceneName)
        //{
        //    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        //    operation.allowSceneActivation = false;

        //    while(!operation.isDone)
        //    {
        //        Debug.Log("Прогресс: " + Mathf.Clamp01(operation.progress / 0.9f));
        //        //_loadIcon.style.rotate = new Rotate(5f);
        //    }
        //    if(operation.progress>=0.9f)
        //    {
        //        yield return new WaitForSeconds(0.5f);
        //        operation.allowSceneActivation = true;
        //    }
        //    yield return null;
        //}
    }
}
