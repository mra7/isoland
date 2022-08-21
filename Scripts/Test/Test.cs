using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Awake()
    {
        //EventCenter.AddListener<string>(EventType.Test, TestF1);
    }
    private void OnDestroy()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            EventCenter.Boardcast<AudioSourceType, string, bool, float> (EventType.PlaySound, AudioSourceType.BackGround, "OpenRoad", true, 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            EventCenter.Boardcast<AudioSourceType>(EventType.StopSound, AudioSourceType.BackGround);
        }
    }
    void TestFun()
    {
        
    }

}
