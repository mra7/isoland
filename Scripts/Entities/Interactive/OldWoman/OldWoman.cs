using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldWoman : InteractiveBase
{
    protected override void GetClick(ItemName currentItemName, string id)
    {
        if(id == this.interactiveId)
        {
            if(currentItemName == requireItem)
            {
                Debug.Log("我要的正是" + currentItemName);
                isDone = true;
            }
            else
            {
                Debug.Log("我要的是" + requireItem + "而不是" + currentItemName);
            }
        }
    }
}
