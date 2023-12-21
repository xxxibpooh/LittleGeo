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
                return true;
            case "BananaPeel":
                itemName = ItemName.BananaPeel;
                return true;
            case "Can":
                itemName = ItemName.Can;
                return true;
            // ���������Ʒ��ƥ��
            default:
                return false;
        }
    }
}
