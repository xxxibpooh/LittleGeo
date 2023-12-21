using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CrowUI : MonoBehaviour, IDropHandler
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
                EventHandler.CallCrowInteractiveEvent(itemName);
                Debug.Log("CallItemInteractiveEvent: " + itemName);
            }
            else
            {

                Debug.Log("不能交互");
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
/*            case ItemName.Coin:
                m_itemName = ItemName.Coin;
                return true;*/
            case ItemName.BirdFood:
                m_itemName = ItemName.BirdFood;
                return true;
            // 添加其他物品的匹配
            default:
                return false;
        }
    }
}
