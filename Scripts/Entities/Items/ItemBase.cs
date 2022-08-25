using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

namespace isoLand.Models
{
    public class ItemBase : MonoBehaviour
    {
        [SerializeField] public string itemId;
        [SerializeField] protected ItemName itemName;
        protected void Awake()
        {
            EventCenter.AddListener<string>(MyEventType.ClickItem, GetClicked);
        }
        protected void OnDestroy()
        {
            EventCenter.RemoveListener<string>(MyEventType.ClickItem, GetClicked);
        }
        protected virtual void Start()
        {
            itemId = System.Guid.NewGuid().ToString();
        }
        protected virtual void GetClicked(string id)
        {

        }
    }
}

