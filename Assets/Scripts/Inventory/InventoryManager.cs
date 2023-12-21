using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public ItemDataList_SO itemData;

    [SerializeField] private List<ItemName> itemList = new List<ItemName>();

    private void OnEnable()
    {
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
    }
    private void OnDisable()
    {
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
    }
    private void OnItemUsedEvent(ItemName itemName)
    {
        var index = itemList.IndexOf(itemName);
        if (index >= 0) // 检查 index 是否有效
        {
            itemList.RemoveAt(index);
            EventHandler.CallRemoveSlotEvent(index);
        }
    }
    public void AddItem(ItemName itemName)
    {
        if (!itemList.Contains(itemName))
        {
            itemList.Add(itemName);
            EventHandler.CallAddItemSlotEvent(itemData.GetItemDetails(itemName));
        }
    }
    public List<ItemName> GetItemList()
    {
        return itemList;
    }
}
