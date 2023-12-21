using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crow : Interactive
{
    public ItemName Tape;
    public GameObject tape;
    [SerializeField] private Canvas talkCanvas;
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.CrowInteractiveEvent += OnCrowInteractiveEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
    }

    private void OnAfterSceneLoadedEvent()
    {
        if(isDone)
        {
            if (tape != null)
            {
                tape.gameObject.SetActive(false);
            }
        }
    }

    private void OnCrowInteractiveEvent(ItemName itemName)
    {
        Debug.Log("OnCrowInteractiveEvent");
        if (!isDone)
        {
            isDone = true;
            EventHandler.CallItemUsedEvent(itemName);
            if (tape != null)
                tape.gameObject.SetActive(false);
            if(talkCanvas != null)
                talkCanvas.gameObject.SetActive(false);
            InventoryManager.Instance.AddItem(Tape);
            Debug.Log("Éú³ÉTape");
            //EventHandler.CrowInteractiveEvent -= OnCrowInteractiveEvent;
        }
    }
}
