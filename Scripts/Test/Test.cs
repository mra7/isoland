using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class Test : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            EventCenter.Boardcast<AudioSourceType, string, bool, float> (MyEventType.PlaySound, AudioSourceType.BackGround, "OpenRoad", true, 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            EventCenter.Boardcast<AudioSourceType>(MyEventType.StopSound, AudioSourceType.BackGround);
        }
    }
}
