using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SmokeUI : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            ItemName itemName;
            Debug.Log("OnDrop");
            itemName = eventData.pointerDrag.gameObject.GetComponent<SlotUI>().currentItem.itemName;
            Debug.Log(itemName);
            if (TryCheckItemName(itemName))
            {
                EventHandler.CallSmokeHeavyInteractiveEvent(itemName);
                Debug.Log("CallSmokeHeavyInteractiveEvent " + itemName);
            }
            else if(itemName==ItemName.BottleWater)
            {
                EventHandler.CallSmokeExtinguishInteractiveEvent(itemName);
                Debug.Log("CallSmokeExtinguishInteractiveEvent " + itemName);
            }
            else
            {
                Debug.Log("无法解析的物品名称");
            }
        }
    }

    private bool TryCheckItemName(ItemName m_itemName)
    {

        switch (m_itemName)
        {
            case ItemName.AppleCore:
                m_itemName = ItemName.AppleCore;
                return true;
            case ItemName.BananaPeel:
                m_itemName = ItemName.BananaPeel;
                return true;
            case ItemName.Can:
                m_itemName = ItemName.Can;
                return true;
            // 添加其他物品的匹配
            default:
                return false;
        }
    }
}
