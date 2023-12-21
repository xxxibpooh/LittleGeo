using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEmotion : Interactive
{
    public GameObject playerHappy;
    public GameObject playerAngry;


    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.PlayerBecomeHappy += OnPlayerBecomeHappy;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
    }

    private void OnAfterSceneLoadedEvent()
    {
        if (!isDone)
        {
            if (playerAngry != null)
                playerAngry.SetActive(true);
            if (playerHappy != null)
                playerHappy.SetActive(false);
        }
        else
        {
            if (playerAngry != null)
            {
                playerAngry.SetActive(false);
            }
            if (playerHappy != null)
                playerHappy.SetActive(true);
        }
    }
    private void OnPlayerBecomeHappy()
    {
        if (!isDone)
        {
            isDone = true;
            if (playerAngry != null)
                playerAngry.SetActive(false);
            if(playerHappy != null)
                playerHappy.SetActive(true);
        }
    }
}
