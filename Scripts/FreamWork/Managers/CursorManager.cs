using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    private Vector3 mousePosition;
    private bool canClick = true;
    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
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
    private void OnClicked(GameObject clickedObj)
    {
        if (clickedObj != null)
        {

            switch (clickedObj.tag)
            {
                case "Teleport":
                    EventCenter.Boardcast<int>(EventType.ClickTeleport, clickedObj.GetComponent<Teleport>().id);
                    break;
            }
        }
            
        //switch
    }
    private Collider2D GetObjAtMoustPosition()
    {
        return Physics2D.OverlapPoint(mousePosition);
    }
}
