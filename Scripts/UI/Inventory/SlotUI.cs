using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using EventSystem;

public class SlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemImage;
    private ItemDetails currentItem;
    private bool isSelected;
    public void SetItem(ItemDetails itemDetails)
    {
        currentItem = itemDetails;
        this.gameObject.SetActive(true);
        Debug.Log(itemDetails.itemName);
        itemImage.sprite = itemDetails.sprite;
        itemImage.SetNativeSize();
    }
    public void SetEmpty()
    {
        this.gameObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        isSelected = !isSelected;
        if(isSelected)
        {
            EventCenter.Boardcast<ItemName>(MyEventType.HoldSomething, currentItem.itemName);
        }
        else if(!isSelected)
        {
            EventCenter.Boardcast(MyEventType.NoHold);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }
}
