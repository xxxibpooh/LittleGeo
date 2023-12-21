using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLake : Interactive
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
        else
        {
            //dialogueController.ShowDialogeStart();
            StartCoroutine(AutoPlayDialogue());
        }
    }

    private IEnumerator AutoPlayDialogue()
    {
        while (dialogueController.dialogueStartStack.Count > 0)
        {
            dialogueController.ShowDialogeStart();
            yield return new WaitForSeconds(1.5f);
        }
        isDone = true;
        EventHandler.CallHideDialogueEvent();
        EventHandler.CallGameStateChangeEvent(GameState.GamePlay);
    }
}
