using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : Interactive
{
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.TrashBinInteractiveEvent += OnTrashBinInteractiveEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
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

    private void OnTrashBinInteractiveEvent(ItemName itemName)
    {
        Debug.Log("OnTrashBinInteractiveEvent");
        EventHandler.CallItemUsedEvent(itemName);
        Debug.Log("ÈÓÀ¬»ø");
    }
}
