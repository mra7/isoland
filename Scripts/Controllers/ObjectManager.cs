using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using isoLand.Models;

public class ObjectManager : MonoBehaviour
{
    // 用于管理场景内item的available状态
    Dictionary<ItemName, bool> itemAvailableDic = new Dictionary<ItemName, bool>();
    private void Awake()
    {
        EventCenter.AddListener(MyEventType.BeforeScenceChange, BeforeScenceChange);
        EventCenter.AddListener(MyEventType.AfterScenceChange, AfterScenceChange);
        EventCenter.AddListener<ItemName, bool>(MyEventType.ChangeItemAvailable, ChangeItemAvailableState);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(MyEventType.BeforeScenceChange, BeforeScenceChange);
        EventCenter.RemoveListener(MyEventType.AfterScenceChange, AfterScenceChange);
        EventCenter.RemoveListener<ItemName, bool>(MyEventType.ChangeItemAvailable, ChangeItemAvailableState);
    }
    private void BeforeScenceChange()
    {
        foreach (var item in FindObjectsOfType<ItemBase>())
        {
            if (!itemAvailableDic.ContainsKey(item.itemName))
            {
                itemAvailableDic.Add(item.itemName, true);
            }
        }
    }
    private void AfterScenceChange()
    {
        foreach (var item in FindObjectsOfType<ItemBase>())
        {
            // 不包含代表没被交互过所以可以被交互
            if (!itemAvailableDic.ContainsKey(item.itemName))
            {
                itemAvailableDic.Add(item.itemName, true);
            }
            else
            {
                item.gameObject.SetActive(itemAvailableDic[item.itemName]);
            }
        }
    }
    private void ChangeItemAvailableState(ItemName itemName, bool state)
    {
        itemAvailableDic[itemName] = state;
    }
}
