using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventoryManager inventory;

    [SerializeField] private GameObject pfbItemSlot;

    public int currentIndex;

    Dictionary<ItemName, Sprite> itemSprites = new Dictionary<ItemName, Sprite>();
    public Sprite AppleCore;
    public Sprite BananaPeel;
    public Sprite Bottle;
    public Sprite BottleWater;
    public Sprite Can;
    public Sprite Coin;
    public Sprite Tape;
    public Sprite Tourist;
    public Sprite BirdFood;
    private void Awake()
    {
        itemSprites[ItemName.AppleCore] = AppleCore;
        itemSprites[ItemName.BananaPeel] = BananaPeel;
        itemSprites[ItemName.Bottle] = Bottle;
        itemSprites[ItemName.BottleWater] = BottleWater;
        itemSprites[ItemName.Can] = Can;
        itemSprites[ItemName.Coin] = Coin;
        itemSprites[ItemName.Tape] = Tape;
        itemSprites[ItemName.Tourist] = Tourist;
        itemSprites[ItemName.BirdFood] = BirdFood;
    }
    private void OnEnable()
    {
        //EventHandler.UpdateUIEvent += OnUpdateUIEvent;
        EventHandler.AddItemSlotEvent += AddSlot;
        EventHandler.RemoveSlotEvent += RemoveSlot;
    }


    private void OnDisable()
    {

    }

    private void AddSlot(ItemDetails itemDetails)
    {
        Instantiate(pfbItemSlot, transform).GetComponent<SlotUI>().Initialize(itemDetails);
    }

    private void RemoveSlot(int index)
    {
        Destroy(transform.GetChild(index).gameObject);
    }
}
