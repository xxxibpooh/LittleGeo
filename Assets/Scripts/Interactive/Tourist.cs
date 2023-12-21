using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourist : Interactive
{
    [SerializeField] private GameObject tourist;

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.TouristInteractiveEvent += OnTouristInteractiveEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
    }

    private void OnAfterSceneLoadedEvent()
    {
        if (!isDone)
        {
            if(tourist != null)
            {
                tourist.SetActive(false);
            }
        }
        else
        {
            if (tourist != null)
            {
                tourist.SetActive(true);
            }
        }
    }

    private void OnTouristInteractiveEvent(ItemName itemName)
    {
        Debug.Log("OnTouristInteractiveEvent");

        if (!isDone)
        {
            isDone = true;
            EventHandler.CallItemUsedEvent(itemName);
            if(tourist != null)
                tourist.SetActive(true);
        }
    }
}
