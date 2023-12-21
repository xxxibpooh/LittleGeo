using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour, IDropHandler
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
                EventHandler.CallWaterInteractiveEvent(itemName);
                Debug.Log("CallItemInteractiveEvent: " + itemName);
            }
            else
            {
                Debug.Log("�޷���������Ʒ����");
            }
        }
    }

    private bool TryGetItemName(Sprite sprite, out ItemName itemName)
    {
        itemName = ItemName.None; // Ĭ��ֵ

        if (sprite == null)
        {
            return false;
        }

        // ���� Sprite �����ƽ���ƥ��
        switch (sprite.name)
        {
            case "AppleCore":
                itemName = ItemName.AppleCore;
                return false;
            case "BananaPeel":
                itemName = ItemName.BananaPeel;
                return false;
            case "Bottle":
                itemName = ItemName.Bottle;
                return true;
            // ���������Ʒ��ƥ��
            default:
                return false;
        }
    }
}