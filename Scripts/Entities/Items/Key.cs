using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
