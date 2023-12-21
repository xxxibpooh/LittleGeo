using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFarmInter : Interactive
{
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject birdFood;

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.CharaterFarmInteractiveEvent += OnCharaterFarmInteractiveEvent; ;
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
            if (hand != null)
                hand.SetActive(false);
            if (birdFood != null)
                birdFood.SetActive(false);

        }
    }

    private void OnCharaterFarmInteractiveEvent(ItemName itemName)
    {
        if (!isDone)
        {
            isDone = true;
            EventHandler.CallItemUsedEvent(itemName);
            if (hand != null)
                hand.SetActive(false);
            if (birdFood != null)
                birdFood.SetActive(false);
            InventoryManager.Instance.AddItem(ItemName.BirdFood);
            Debug.Log("µÃµ½birdfood");
        }
    }
}
