using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrashBinUI : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("OnDrop");
            Image image = eventData.pointerDrag.gameObject.transform.Find("Image").GetComponent<Image>();
            ItemName itemName;
            if (TryGetItemName(image.sprite, out itemName))
            {
                Debug.Log("CallTrashBinInteractiveEvent");
                EventHandler.CallTrashBinInteractiveEvent(itemName);
            }
            else
            {

                Debug.Log("无法解析的物品名称");
            }
        }
    }

    private bool TryGetItemName(Sprite sprite, out ItemName itemName)
    {
        itemName = ItemName.None; // 默认值

        if (sprite == null)
        {
            return false;
        }

        // 根据 Sprite 的名称进行匹配
        switch (sprite.name)
        {
            case "AppleCore":
                itemName = ItemName.AppleCore;
                return true;
            case "BananaPeel":
                itemName = ItemName.BananaPeel;
                return true;
            case "Can":
                itemName = ItemName.Can;
                return true;
            // 添加其他物品的匹配
            default:
                return false;
        }
    }
}
