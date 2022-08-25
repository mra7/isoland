using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadeCanvasGroup;
    [SerializeField] private float duration;
    private void Awake()
    {
        
        EventCenter.AddListener<string>(MyEventType.SceneChangeUIFade, Fade);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener<string>(MyEventType.SceneChangeUIFade, Fade);
    }
    private void Start()
    {
        //fadeCanvasGroup = GetComponent<CanvasGroup>();
    }
    private void Fade(string type)
    {
        if (type == "fadeIn")
        {
            StartCoroutine(FadeIE(0f));
        }
        else if (type == "fadeOut")
        {
            StartCoroutine(FadeIE(1f));
        }

    }
    private IEnumerator FadeIE(float targetAlpha)
    {
        fadeCanvasGroup.blocksRaycasts = true;
        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / duration;
        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }
        fadeCanvasGroup.blocksRaycasts = false;
    }
}
