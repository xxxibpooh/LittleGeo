using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : Interactive
{
    public GameObject smoke;
    public GameObject smokeParticle;
    public GameObject playerHappy;
    public GameObject playerAngry;
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.SmokeHeavyInteractiveEvent += OnSmokeHeavyInteractiveEvent;
        EventHandler.SmokeExtinguishInteractiveEvent += OnSmokeExtinguishInteractiveEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
    }

    private void OnAfterSceneLoadedEvent()
    {
        if (!isDone)
        {
            if (smoke != null)
                smoke.SetActive(true);
            if(smokeParticle!= null)
                smokeParticle.SetActive(true);
            if (playerAngry != null)
                playerAngry.SetActive(true);
            if (playerHappy != null)
                playerHappy.SetActive(false);
        }
        else
        {
            if(smoke != null)
                smoke.SetActive(false);
            if(smokeParticle!=null)
                smokeParticle.SetActive(false);
            if (playerAngry != null)
                playerAngry.SetActive(false);
            if (playerHappy != null)
                playerHappy.SetActive(true);
        }
    }

    private void OnSmokeHeavyInteractiveEvent(ItemName itemName)
    {
        if (!isDone)
        {
            EventHandler.CallItemUsedEvent(itemName);
            Debug.Log("Ã°»ð¼ÓÖØ");
        }
    }

    private void OnSmokeExtinguishInteractiveEvent(ItemName itemName)
    {
        if (!isDone)
        {
            isDone = true;
            EventHandler.CallItemUsedEvent(itemName);

            if (smoke != null)
                smoke.SetActive(false);
            if (smokeParticle != null)
                smokeParticle.SetActive(false);
            if (playerAngry != null)
                playerAngry.SetActive(false);
            if (playerHappy != null)
                playerHappy.SetActive(true);
            Debug.Log("Ãð»ð");
        }
    }

}
