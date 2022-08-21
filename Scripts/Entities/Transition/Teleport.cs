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
        // ͨ���㲥�¼����ݱ���������id�ж��Ƿ�ִ������
        if (clickedId == id)
        {
            EventCenter.Boardcast<string, string>(EventType.ScenceChange, scenceFrom, scenceTo);
        }
    }
}
