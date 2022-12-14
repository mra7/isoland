using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EventSystem;

public class TransitionManager :MonoBehaviour
{
    void Awake()
    {
        EventCenter.AddListener<string, string>(MyEventType.ScenceChange, ChangeScene);
    }
    private void Start()
    {
        EventCenter.Boardcast<string>(MyEventType.SceneChangeUIFade, "fadeIn");
    }
    private void ChangeScene(string from, string to)
    {
        StartCoroutine(ChangeSceneIE(from, to));
    }
    private IEnumerator ChangeSceneIE(string from, string to)
    {
        EventCenter.Boardcast<string>(MyEventType.SceneChangeUIFade, "fadeOut");
        yield return new WaitForSeconds(0.35f);
        yield return SceneManager.UnloadSceneAsync(from);
        // 未加载完时进行等待
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
        //var loadOver = SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
        //while (loadOver.isDone) yield return null;
        var newScene = SceneManager.GetSceneByName(to);
        SceneManager.SetActiveScene(newScene);
        yield return new WaitForSeconds(0.35f);
        EventCenter.Boardcast<string>(MyEventType.SceneChangeUIFade, "fadeIn");
    }
    void OnDestroy()
    {
        EventCenter.RemoveListener<string, string>(MyEventType.ScenceChange, ChangeScene);
    }
}
