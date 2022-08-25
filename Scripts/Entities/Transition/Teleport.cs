using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class Teleport : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] private string scenceFrom;
    [SerializeField] private string scenceTo;
    private void Awake()
    {
        EventCenter.AddListener<int>(MyEventType.ClickTeleport, GetClicked);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener<int>(MyEventType.ClickTeleport, GetClicked);
    }
    private void GetClicked(int clickedId)
    {
        // ͨ���㲥�¼����ݱ���������id�ж��Ƿ�ִ������
        if (clickedId == id)
        {
            EventCenter.Boardcast<string, string>(MyEventType.ScenceChange, scenceFrom, scenceTo);
        }
    }
}
