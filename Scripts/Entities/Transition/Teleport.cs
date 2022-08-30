using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

namespace isoLand.Models
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] public string teleportId;
        [SerializeField] private string scenceFrom;
        [SerializeField] private string scenceTo;
        private void Awake()
        {
            EventCenter.AddListener<string>(MyEventType.ClickTeleport, GetClicked);
        }
        private void OnDestroy()
        {
            EventCenter.RemoveListener<string>(MyEventType.ClickTeleport, GetClicked);
        }
        private void Start()
        {
            teleportId = System.Guid.NewGuid().ToString();
        }
        private void GetClicked(string clickedId)
        {
            // 通过广播事件传递被点击对象的id判断是否执行自身。
            if (teleportId == clickedId)
            {
                EventCenter.Boardcast<string, string>(MyEventType.ScenceChange, scenceFrom, scenceTo);
            }
        }
    }
}


