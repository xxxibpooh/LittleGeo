using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public GameObject panel;
    public Image TalkContent;

    private void OnEnable()
    {
        EventHandler.ShowDialogueEvent += ShowDialogue;
        EventHandler.HideDialogueEvent += HideDialogue;
    }

    private void OnDisable()
    {
        EventHandler.ShowDialogueEvent -= ShowDialogue;
        EventHandler.HideDialogueEvent -= HideDialogue;
    }


    private void ShowDialogue(Sprite dialogue)
    {
        if(dialogue)
            panel.SetActive(true);
        else 
            panel.SetActive(false);
        TalkContent.sprite = dialogue;
        
    }
    private void HideDialogue()
    {
        panel.SetActive(false);
    }
}
