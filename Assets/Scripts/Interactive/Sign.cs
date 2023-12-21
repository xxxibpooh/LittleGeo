using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sign : Interactive
{
    [SerializeField] private GameObject signBroken;
    [SerializeField] private GameObject signFixed;
    [SerializeField] private GameObject tourist;
    [SerializeField] private GameObject CraneScared;
    [SerializeField] private GameObject CraneHappy;
    [SerializeField] private Animator exploAnimator;

    public GameObject playerAngry;
    public GameObject playerHappy;


    

    private void Start()
    {
        exploAnimator.SetBool("IsExplosion", false);
    }

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.SignInteractiveEvent += OnSignInteractiveEvent;
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
            if (signBroken != null)
                signBroken.SetActive(false);
            if (signFixed != null)
                signFixed.SetActive(true);
            if (tourist != null)
                tourist.SetActive(false);
            if (CraneScared != null)
                CraneScared.SetActive(false);
            if (CraneHappy != null)
                CraneHappy.SetActive(true);

            if (playerAngry != null)
                playerAngry.SetActive(false);
            if (playerHappy != null)
                playerHappy.SetActive(true);
        }
    }
    private void OnSignInteractiveEvent(ItemName itemName)
    {
        if (!isDone)
        {
            isDone = true;
            if(exploAnimator != null)
                exploAnimator.SetBool("IsExplosion", true);

            EventHandler.CallItemUsedEvent(itemName);
            if (signBroken != null)
                signBroken.SetActive(false);
            if (signFixed != null)
                signFixed.SetActive(true);


            if (tourist != null)
                tourist.SetActive(false);
            InventoryManager.Instance.AddItem(ItemName.Tourist);


            if (CraneScared != null)
                CraneScared.SetActive(false);
            if (CraneHappy != null)
                CraneHappy.SetActive(true);


            if (playerAngry != null)
                playerAngry.SetActive(false);
            if (playerHappy != null)
                playerHappy.SetActive(true);

            Debug.Log("ÐÞºÃSign");
        }
    }
/*    private IEnumerator RepairSignWithDelay(ItemName itemName)
    {
        Debug.Log("OnSignInteractiveEvent");
        if (!isDone)
        {
            isDone = true;
            EventHandler.CallItemUsedEvent(itemName);
            if (signBroken != null)
                signBroken.SetActive(false);
            if (signFixed != null)
                signFixed.SetActive(true);
            yield return new WaitForSeconds(1f);

            if (tourist != null)
                tourist.SetActive(false);
            InventoryManager.Instance.AddItem(ItemName.Tourist);
            yield return new WaitForSeconds(1f);

            if (CraneScared != null)
                CraneScared.SetActive(false);
            if (CraneHappy != null)
                CraneHappy.SetActive(true);
            EventHandler.CallPlayerBecameHappy();

            Debug.Log("ÐÞºÃSign");
        }
    }*/
}
