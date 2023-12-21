using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouristUI : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            ItemName itemName;
            Debug.Log("OnDrop");
            itemName = eventData.pointerDrag.gameObject.GetComponent<SlotUI>().currentItem.itemName;
            Debug.Log(itemName);
            if (itemName == ItemName.Tourist)
            {
                EventHandler.CallTouristInteractiveEvent(itemName);
                Debug.Log("CallTouristInteractiveEvent: " + itemName);
            }
            else
            {

                Debug.Log("未放置Tourist，不需要交互");
            }
        }
    }
}