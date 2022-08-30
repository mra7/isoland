using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataList_SO", menuName = "ScriptObject/ItemDataList_SO")]
public class ItemDataList_SO : ScriptableObject
{
    public List<ItemDetails> itemDetailsList;
    public ItemDetails GetItemDetails(ItemName name)
    {
        return itemDetailsList.Find(i => i.itemName == name);
    }

}
[System.Serializable]
public class ItemDetails
{
    public ItemName itemName;
    public Sprite sprite;
}
