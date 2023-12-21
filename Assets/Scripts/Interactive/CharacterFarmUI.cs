using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterFarmUI : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            ItemName itemName;
            Debug.Log("OnDrop");
            itemName = eventData.pointerDrag.gameObject.GetComponent<SlotUI>().currentItem.itemName;
            Debug.Log(itemName);
            if (itemName == ItemName.Coin)
            {
                EventHandler.CallCharacterFarmInteractiveEvent(itemName);
                Debug.Log("CallCharacterFarmInteractiveEvent: " + itemName);
            }
            else
            {

                Debug.Log("无法解析的物品名称");
            }
        }
    }
}
