using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] private string scenceFrom;
    [SerializeField] private string scenceTo;
    
    private void Awake()
    {
        EventCenter.AddListener<int>(EventType.ClickTeleport, Clicked);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener<int>(EventType.ClickTeleport, Clicked);
    }
    private void Clicked(int clickedId)
    {
        if (clickedId == id)
        {
            EventCenter.Boardcast<string, string>(EventType.ScenceChange, scenceFrom, scenceTo);
        }
    }
}
