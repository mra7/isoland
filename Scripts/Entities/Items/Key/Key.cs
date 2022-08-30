using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

namespace isoLand.Models
{
    public class Key : ItemBase
    {
        protected override void GetClicked(string id)
        {
            if (id == itemId)
            {
                //gameObject.SetActive(false);
                EventCenter.Boardcast<ItemName>(MyEventType.AddItem, ItemName.Key);
                DestroyImmediate(gameObject);
            }
        }
    }
}

