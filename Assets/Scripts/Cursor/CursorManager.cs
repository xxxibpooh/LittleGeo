using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    private bool ableClick;

    private ItemName currentItem;
    private bool holdItem;

    private void OnEnable()
    {
        EventHandler.ItemSelectedEvent += OnItemSelectedEvent;
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemSelectedEvent -= OnItemSelectedEvent;
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
    }

    private void Update()
    {
        ableClick = ObjectAtMousePosition();

        if (ableClick && Input.GetMouseButtonDown(0))
        {
            ClickAction(ObjectAtMousePosition().gameObject);
        }
    }
    private void OnItemUsedEvent(ItemName itemName)
    {
        currentItem = ItemName.None;
        holdItem = false;
    }
    private void OnItemSelectedEvent(ItemDetails itemDetails, bool isSelected)
    {
        holdItem = isSelected;

        if(isSelected)
        {
            currentItem = itemDetails.itemName;
        }
    }

    private void ClickAction(GameObject clickObject)
    {
        switch (clickObject.tag)
        {
            case "Teleport":
                var teleport = clickObject.GetComponent<Teleport>();
                teleport?.TeleportToScene();
                EventHandler.CallClickMusic();
                break;
            case "Item":
                var item = clickObject.GetComponent<Item>();
                item?.ItemClicked();
                EventHandler.CallClickMusic();
                break;
            case "Interactive":
                var interactive = clickObject.GetComponent<Interactive>();
                if(holdItem)
                    interactive?.CheckItem(currentItem);
                else
                    interactive?.EmptyClicked();
                break;
            case "Insect":
                EventHandler.CallInsectAnim();
                EventHandler.CallClickMusic();
                Debug.Log("µã»÷³æ×Ó");
                break;
            case "Birds":
                EventHandler.CallBirdAnim();
                EventHandler.CallClickMusic();
                Debug.Log("µã»÷Äñ");
                break;
            case "Coin":
                var coin = clickObject.GetComponent<Item>();
                coin?.ItemClicked();
                EventHandler.CallCoinPicked();
                break;
        }
    }

    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}
