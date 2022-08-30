using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventSystem;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private int currentItemId;
    [SerializeField] private SlotUI slotUI;
    private void Awake()
    {
        EventCenter.AddListener<ItemDetails, int>(MyEventType.InventoryUIUpdate, OnInventoryUIUpdate);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener<ItemDetails, int>(MyEventType.InventoryUIUpdate, OnInventoryUIUpdate);
    }
    private void OnInventoryUIUpdate(ItemDetails itemDetails, int id)
    {
        if (itemDetails == null)
        {
            slotUI.SetEmpty();
            currentItemId = -1;
            leftButton.interactable = false;
            rightButton.interactable = false;
        }
        else
        {
            currentItemId = id;
            slotUI.SetItem(itemDetails);
        }
    }

}
