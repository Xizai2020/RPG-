using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager :Singleton<LoadManager>
{
    public GameObject loadScree;
    public Slider slider;
    public Text text;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        loadScree.gameObject.SetActive(false);
    }
    public void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }
    IEnumerator LoadScene(string sceneName)
    {
        loadScree.gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            slider.value = operation.progress;
            text.text = "¼ÓÔØÖÐ¡­¡­" + operation.progress * 100 + "%";
            if (operation.progress >= 0.9)
            {
                slider.value = 1;
                operation.allowSceneActivation = true;
                loadScree.gameObject.SetActive(false);
            }
            yield return null;
        }

    }
}
