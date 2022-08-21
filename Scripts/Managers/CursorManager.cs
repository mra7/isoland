using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    private Vector3 mousePosition;
    private bool canClick = true;
    private void Update()
    {
        GetMousePosition();
        if (canClick && Input.GetMouseButtonDown(0))
        {
            if (GetObjAtMoustPosition() != null)
            {
                OnClicked(GetObjAtMoustPosition().gameObject);
            }
            else if (GetObjAtMoustPosition() == null)
            {
                OnClicked(null);
            }
            
        }
    }
    // 获取鼠标位置
    private void GetMousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    }
    // 鼠标点击事件
    private void OnClicked(GameObject clickedObj)
    {
        if (clickedObj != null)
        {
            switch (clickedObj.tag)
            {
                case "Teleport":
                    EventCenter.Boardcast<int>(EventType.ClickTeleport, clickedObj.GetComponent<Teleport>().id);
                    break;
                case "Item":
                    EventCenter.Boardcast<string>(EventType.ClickItem, clickedObj.GetComponent<ItemBase>().itemId);
                    break;
            }
        }
            
    }
    private Collider2D GetObjAtMoustPosition()
    {
        return Physics2D.OverlapPoint(mousePosition);
    }
}
