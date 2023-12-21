using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Interactive
{
    //public bool isDone;
    public ItemName BottleWater;
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.WaterInteractiveEvent += OnItemInteractiveEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
    }

    private void OnItemInteractiveEvent(ItemName itemName)
    {
        Debug.Log("执行OnItemInteractiveEvent");
        if (!isDone)
        {
            isDone = true;
            EventHandler.CallItemUsedEvent(itemName);
            InventoryManager.Instance.AddItem(BottleWater);
            Debug.Log("生成装水瓶子");
        }
    }

    private void OnAfterSceneLoadedEvent()
    {
        if (!isDone)
        {
            
        }
        else
        {

        }
    }


}
