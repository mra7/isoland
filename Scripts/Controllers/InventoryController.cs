using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private ItemDataList_SO itemData;
    [SerializeField] private List<ItemName> itemList;
    public void Init()
    {
        itemList = new List<ItemName>();
        EventCenter.AddListener<ItemName>(MyEventType.AddItem, AddItem);
    }
    void OnDestroy()
    {
        EventCenter.RemoveListener<ItemName>(MyEventType.AddItem, AddItem);
    }
    private void AddItem(ItemName itemName)
    {
        if (!itemList.Contains(itemName))
        {
            itemList.Add(itemName);
            EventCenter.Boardcast<ItemDetails, int>(MyEventType.InventoryUIUpdate, itemData.GetItemDetails(itemName), itemList.Count - 1);
        }
    }
}
