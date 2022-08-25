using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace isoLand.Models
{
    public class Key : ItemBase
    {
        protected override void GetClicked(string id)
        {
            if (id == itemId)
            {
                //gameObject.SetActive(false);
                DestroyImmediate(gameObject);
            }
        }
    }
}

