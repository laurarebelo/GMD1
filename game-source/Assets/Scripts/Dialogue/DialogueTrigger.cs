using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Dialogue;
using UnityEngine;
public class DialogueTrigger : MonoBehaviour
{
    private int currentIndex;
    public TextAsset[] dialogueJsons;
    private DialogueLine[] dialogueLines;

    private void Start()
    {
        currentIndex = 0;
    }

    public void TriggerDialogue()
    {
        if (currentIndex < dialogueJsons.Length)
        {
            bool isFinal = currentIndex == dialogueJsons.Length - 1;
            string jsonString = dialogueJsons[currentIndex].ToString();
            DialogueLineList lineList = JsonUtility.FromJson<DialogueLineList>(jsonString);
            dialogueLines = lineList.dialogue;
            StartDialogueOnEitherManager(isFinal);
            currentIndex++; 
        }
        else
        {
            Debug.Log("CURRENT DIALOGUE INDEX IS BIGGER THAN THE LENGTH OF THE DIALOGUE JSONS...");
        }
    }

    private void StartDialogueOnEitherManager(bool isFinal)
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        DialogueMgr dialogueMgr = FindObjectOfType<DialogueMgr>();
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue(dialogueLines, isFinal);
        }

        if (dialogueMgr != null)
        {
            dialogueMgr.StartDialogue(dialogueLines, isFinal);
        }
    }
}
