using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneFader : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public float fadeInDuration;
    public float fadeOutDuratoion;
    
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        DontDestroyOnLoad(this);
    }
    public IEnumerator FadeOutIn()
    {
        yield return FadeOut(fadeOutDuratoion);
        yield return FadeIn(fadeInDuration);
    }
    public IEnumerator FadeOut(float time)
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime/time;
            yield return null;
        }
        yield break;
    }
    public IEnumerator FadeIn(float time)
    {
        while (canvasGroup.alpha !=0)
        {
            canvasGroup.alpha -= Time.deltaTime/time;
            yield return null;
        }

        Destroy(gameObject,1);
        yield break;
    }

}
