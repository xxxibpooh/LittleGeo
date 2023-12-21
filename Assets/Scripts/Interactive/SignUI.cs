using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SignUI : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            ItemName itemName;
            Debug.Log("OnDrop");
            itemName = eventData.pointerDrag.gameObject.GetComponent<SlotUI>().currentItem.itemName;
            Debug.Log(itemName);
            if (itemName == ItemName.Tape)
            {
                EventHandler.CallSignInteractiveEvent(itemName);
                Debug.Log("CallSignInteractiveEvent: " + itemName);
            }
            else
            {

                Debug.Log("无法解析的物品名称");
            }
        }
    }
}
