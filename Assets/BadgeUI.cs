using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgeUI : MonoBehaviour
{
    [SerializeField] private GameObject badgesSlot;

    public Sprite coinSprite;
    public Sprite smokeSprite;
    public Sprite trashSprite;

    private void Start()
    {
        EventHandler.CoinPicked += EventHandler_CoinPicked;
        EventHandler.TrashBinInteractiveEvent += EventHandler_TrashBinInteractiveEvent;
        EventHandler.SmokeExtinguishInteractiveEvent += EventHandler_SmokeExtinguishInteractiveEvent;
    }

    private void EventHandler_SmokeExtinguishInteractiveEvent(ItemName obj)
    {
        AddBadgesSlot(smokeSprite);
    }

    private void EventHandler_TrashBinInteractiveEvent(ItemName obj)
    {
        AddBadgesSlot(trashSprite);
        EventHandler.TrashBinInteractiveEvent-=EventHandler_TrashBinInteractiveEvent;

    }

    private void EventHandler_CoinPicked()
    {
        AddBadgesSlot(coinSprite);
    }

    private void AddBadgesSlot(Sprite badgeSprite)
    {
        Instantiate(badgesSlot, transform).GetComponent<BadgesSlotUI>().SetImage(badgeSprite);
    }
}
