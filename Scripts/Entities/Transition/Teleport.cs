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
        EventCenter.AddListener<int>(EventType.ClickTeleport, GetClicked);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener<int>(EventType.ClickTeleport, GetClicked);
    }
    private void GetClicked(int clickedId)
    {
        // 通过广播事件传递被点击对象的id判断是否执行自身。
        if (clickedId == id)
        {
            EventCenter.Boardcast<string, string>(EventType.ScenceChange, scenceFrom, scenceTo);
        }
    }
}
