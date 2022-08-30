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
            //EventCenter.Boardcast<AudioSourceType, string, bool, float>(MyEventType.PlaySound, AudioSourceType.BackGround, "OpenRoad", true, 0.5f);
            EventCenter.Boardcast(MyEventType.AfterScenceChange);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            EventCenter.Boardcast<AudioSourceType>(MyEventType.StopSound, AudioSourceType.BackGround);
        }
    }
}
