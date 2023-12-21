using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public static class EventHandler
{
    public static event Action<ItemDetails> AddItemSlotEvent;
    public static void CallAddItemSlotEvent(ItemDetails itemDetails)
    {
        AddItemSlotEvent?.Invoke(itemDetails);
    }

    public static event Action<int> RemoveSlotEvent;
    public static void CallRemoveSlotEvent(int index)
    {
        RemoveSlotEvent?.Invoke(index);
    }

    public static event Action BeforeSceneUnloadEvent;
    public static void CallBeforeSceneUnloadEvent()
    {
        BeforeSceneUnloadEvent?.Invoke();
    }

    public static event Action AfterSceneLoadedEvent;
    public static void CallAfterSceneLoadedEvent()
    {
        AfterSceneLoadedEvent?.Invoke();
    }

    public static event Action<ItemDetails, bool> ItemSelectedEvent;
    public static void CallItemSelectedEvent(ItemDetails itemDetails, bool isSelected)
    {
        ItemSelectedEvent?.Invoke(itemDetails, isSelected);
    }

    public static event Action<ItemName> ItemUsedEvent;
    public static void CallItemUsedEvent(ItemName itemName)
    {
        ItemUsedEvent?.Invoke(itemName);
    }





    public static event Action<ItemName> WaterInteractiveEvent;

    public static void CallWaterInteractiveEvent(ItemName itemName)
    {
        WaterInteractiveEvent?.Invoke(itemName);
    }

    public static event Action<ItemName> CrowInteractiveEvent;
    public static void CallCrowInteractiveEvent(ItemName itemName)
    {
        CrowInteractiveEvent?.Invoke(itemName);
    }

    public static event Action<ItemName> SignInteractiveEvent;
    public static void CallSignInteractiveEvent(ItemName itemName)
    {
        SignInteractiveEvent?.Invoke(itemName);
    }

    public static event Action<ItemName> TrashBinInteractiveEvent;

    public static void CallTrashBinInteractiveEvent(ItemName itemName)
    {
        TrashBinInteractiveEvent?.Invoke(itemName);
    }

    public static event Action<ItemName> SmokeHeavyInteractiveEvent;
    public static void CallSmokeHeavyInteractiveEvent(ItemName itemName)
    {
        SmokeHeavyInteractiveEvent?.Invoke(itemName);
    }

    public static event Action <ItemName> SmokeExtinguishInteractiveEvent;
    public static void CallSmokeExtinguishInteractiveEvent(ItemName itemName)
    {
        SmokeExtinguishInteractiveEvent?.Invoke(itemName);
    }

    public static event Action<ItemName> TouristInteractiveEvent;
    public static void CallTouristInteractiveEvent(ItemName itemName)
    {
        TouristInteractiveEvent?.Invoke(itemName);
    }
    
    public static event Action<ItemName> CharaterFarmInteractiveEvent;
    public static void CallCharacterFarmInteractiveEvent(ItemName itemName)
    {
        CharaterFarmInteractiveEvent?.Invoke(itemName);
    }

    public static event Action PlayerBecomeHappy;
    public static void CallPlayerBecameHappy()
    {
        PlayerBecomeHappy?.Invoke();
    }

    public static event Action CoinPicked;
    public static void CallCoinPicked()
    {
        CoinPicked?.Invoke();
    }


    public static event Action<Sprite> ShowDialogueEvent;
    public static void CallShowDialogueEvent(Sprite dialogue)
    {
        ShowDialogueEvent?.Invoke(dialogue);
    }



    public static event Action HideDialogueEvent;
    public static void CallHideDialogueEvent()
    {
        HideDialogueEvent?.Invoke();
    }

    public static event Action DialogueEnable;
    public static void CallDialogueEnable()
    {
        DialogueEnable?.Invoke();
    }

    public static event Action<GameState> GameStateChangeEvent;

    public static void CallGameStateChangeEvent(GameState gameState)
    {
        GameStateChangeEvent?.Invoke(gameState);
    }



    //Animation
    public static event Action ShowMap;
    public static void CallShowMap()
    {
        ShowMap?.Invoke();
    }

    public static event Action InsectAnim;
    public static void CallInsectAnim()
    {
        InsectAnim?.Invoke();
    }

    public static event Action BirdAnim;
    public static void CallBirdAnim()
    {
        BirdAnim?.Invoke();
    }

    public static event Action PlayerWalk;
    public static void CallPlayerWalk()
    {
        PlayerWalk?.Invoke();
    }



    //Scene
    public static event Action MountainSceneUnlock;
    public static void CallMountainSceneUnlock()
    {
        MountainSceneUnlock?.Invoke();
    }

    public static event Action FarmSceneUnlock;
    public static void CallFarmSceneUnlock()
    {
        FarmSceneUnlock?.Invoke();
    }
    public static event Action CampingsiteSceneUnlock;
    public static void CallCampingsiteSceneUnlock()
    {
        CampingsiteSceneUnlock?.Invoke();
    }
    public static event Action LakeSceneUnlock;
    public static void CallLakeSceneUnlock()
    {
        LakeSceneUnlock?.Invoke();
    }

    //Music
    public static event Action ClickMusic;
    public static void CallClickMusic()
    {
        ClickMusic?.Invoke();
    }
}
