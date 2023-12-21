using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueController))]
public class CharacterMuseum : Interactive
{
    public Animator playerAnimator;
    private DialogueController dialogueController;
    [SerializeField] private GameObject map;
    private Collider2D characterCollider;

    //private bool autoPlayDialogue = false;

    private void Awake()
    {
        dialogueController = GetComponent<DialogueController>();
        characterCollider = GetComponent<Collider2D>();
        characterCollider.enabled = false;
        EventHandler.PlayerWalk += EventHandler_PlayerWalk;
        EventHandler.DialogueEnable += EventHandler_DialogueEnable;

    }

    private void EventHandler_DialogueEnable()
    {
        characterCollider.enabled = true;
    }

    private void EventHandler_PlayerWalk()
    {
        playerAnimator.SetBool("StartWalk", true);
        EventHandler.PlayerWalk -= EventHandler_PlayerWalk;
    }

    private void OnTriggerEnter2D(Collider2D characterCollider)
    {
        if (!isDone)
        {
            dialogueController.ShowDialogeStart();
        }
    }
    
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.ShowMap += OnShowMap;
    }

    private void OnShowMap()
    {
        if(map != null) 
            map.SetActive(true);
    }

    private void OnAfterSceneLoadedEvent()
    {
        if (isDone)
        {
            if(map != null)
                map.SetActive(true);
            if (playerAnimator != null)
                playerAnimator.SetBool("StartWalk", true);
        }
    }

    public override void EmptyClicked()
    {
        if (isDone)
        {
            dialogueController.ShowDialogeFinish();
        }
        else if(!isDone && dialogueController.dialogueStartStack.Count > 0)
        {
            Debug.Log("¿Õµã");
            dialogueController.ShowDialogeStart();
        }
        else
        {
            isDone = true;
            EventHandler.CallShowMap();
            EventHandler.CallHideDialogueEvent();
            EventHandler.CallGameStateChangeEvent(GameState.GamePlay);
        }
    }

}
