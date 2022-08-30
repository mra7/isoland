using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

namespace isoLand.Models
{
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
            // 通过广播事件传递被点击对象的id判断是否执行自身。
            if (clickedId == id)
            {
                EventCenter.Boardcast<string, string>(MyEventType.ScenceChange, scenceFrom, scenceTo);
            }
        }
    }
}


