using System.Collections;
using System.Collections.Generic;
using EventSystem;
using UnityEngine;

public class InteractiveBase : MonoBehaviour
{
    public string interactiveId;
    [SerializeField] protected ItemName requireItem;
    protected bool isDone;
    private void Awake()
    {
      EventCenter.AddListener<ItemName, string>(MyEventType.ClickInteractive, GetClick);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener<ItemName, string>(MyEventType.ClickInteractive, GetClick);
    }
    private void Start()
    {
        interactiveId = System.Guid.NewGuid().ToString();
    }
    protected virtual void GetClick(ItemName currentItemName, string id)
    {

    }
}
