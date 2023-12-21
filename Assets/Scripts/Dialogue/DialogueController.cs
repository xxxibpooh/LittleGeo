using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueData_SO dialogueStart;
    public DialogueData_SO dialogueFinish;

    public Stack<Sprite> dialogueStartStack
    {
        get;
        private set;
    }
    private Stack<Sprite> dialogueFinishStack;

    private bool isTalking;

    private void Awake()
    {
        FillDialogueStack();
    }

    private void FillDialogueStack()
    {
        dialogueStartStack = new Stack<Sprite>();
        dialogueFinishStack = new Stack<Sprite>();

        for(int i = dialogueStart.dialogueList.Count - 1; i > -1; i--)
        {
            dialogueStartStack.Push(dialogueStart.dialogueList[i]);
        }
        for(int i=dialogueFinish.dialogueList.Count - 1;i > -1; i--)
        {
            dialogueFinishStack.Push(dialogueFinish.dialogueList[i]);
        }
    }

    public void ShowDialogeStart()
    {
        if(!isTalking)
        {
            StartCoroutine(DialogueRoutine(dialogueStartStack));
        }
    }

    public void ShowDialogeFinish()
    {
        if (!isTalking)
        {
            StartCoroutine(DialogueRoutine(dialogueFinishStack));
        }
    }

    private IEnumerator DialogueRoutine(Stack<Sprite> data)
    {
        //一开始talking就是true
        //trypop是直接取出，然后移除
        isTalking = true;
        if(data.TryPop(out Sprite result))
        {
            EventHandler.CallShowDialogueEvent(result);
            yield return null;
            isTalking = false;
            //EventHandler.CallGameStateChangeEvent(GameState.Pause);
        }
        else
        {
            EventHandler.CallShowDialogueEvent(null);
            FillDialogueStack();
            isTalking = false;
            //EventHandler.CallGameStateChangeEvent(GameState.GamePlay);
        }
    }
}
