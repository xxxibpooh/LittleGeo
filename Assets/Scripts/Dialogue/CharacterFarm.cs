using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueController))]
public class CharacterFarm : Interactive
{
    private DialogueController dialogueController;

    private void Awake()
    {
        dialogueController = GetComponent<DialogueController>();
    }

    public override void EmptyClicked()
    {
        if (isDone)
        {
            dialogueController.ShowDialogeFinish();
        }
        else if (!isDone && dialogueController.dialogueStartStack.Count > 0)
        {
            Debug.Log("¿Õµã");
            dialogueController.ShowDialogeStart();
        }
        else
        {
            isDone = true;
            EventHandler.CallHideDialogueEvent();
            EventHandler.CallGameStateChangeEvent(GameState.GamePlay);
        }
    }
}
