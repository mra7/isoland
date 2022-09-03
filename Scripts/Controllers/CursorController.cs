using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using UnityEngine.UI;
using isoLand.Models;

namespace isoLand.Controller
{
    public class CursorController
    {
        private Vector3 mousePosition;
        private bool canClick = true;
        [SerializeField] private bool holdItem;
        [SerializeField] private ItemName holdItemName;
        // [SerializeField] public RectTransform hand; 

        public void Init()
        {
            EventCenter.AddListener<ItemName>(MyEventType.HoldSomething, ItemSelected);
            EventCenter.AddListener(MyEventType.NoHold, ItemUnselected);
        }
        public void Destroy()
        {
            EventCenter.RemoveListener<ItemName>(MyEventType.HoldSomething, ItemSelected);
            EventCenter.RemoveListener(MyEventType.NoHold, ItemUnselected);
        }
        public void Tick()
        {
            GetMousePosition();
            if (canClick && Input.GetMouseButtonDown(0))
            {
                if (GetObjAtMoustPosition() != null)
                {
                    //Debug.Log(GetObjAtMoustPosition().gameObject.name);
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
        // 判断是否拿取物品
        private void ItemSelected(ItemName currentItem)
        {
            Debug.Log("拿着："  + currentItem.ToString());
            holdItem = true;
            holdItemName = currentItem;
        }
        private void ItemUnselected()
        {
            Debug.Log("放下物品");
            holdItem = false;
            holdItemName = ItemName.None;
        }
        // 获取点击位置物品
        private Collider2D GetObjAtMoustPosition()
        {
            return Physics2D.OverlapPoint(mousePosition);
        }
        // 鼠标点击事件
        private void OnClicked(GameObject clickedObj)
        {
            if (clickedObj != null)
            {
                switch (clickedObj.tag)
                {
                    case "Teleport":
                        holdItem = false;
                        EventCenter.Boardcast<string>(MyEventType.ClickTeleport, clickedObj.GetComponent<Teleport>().teleportId);
                        break;
                    case "Item":
                        holdItem = false;
                        EventCenter.Boardcast<string>(MyEventType.ClickItem, clickedObj.GetComponent<ItemBase>().itemId);
                        break;
                    case "Interactive":
                        // 需要传递当前拿的东西
                        if(holdItem)
                        {
                            // 发事件
                            var id = clickedObj.GetComponent<InteractiveBase>().interactiveId;
                            EventCenter.Boardcast<ItemName, string>(MyEventType.ClickInteractive, holdItemName, id);
                        }
                        else
                        {
                            Debug.Log("没有拿东西");
                        }
                        break;
                }
            }

        }
        // 更换鼠标图片
        private void ChangeCursorImage()
        {
            if(holdItem)
            {

            }
        }
    }
}

