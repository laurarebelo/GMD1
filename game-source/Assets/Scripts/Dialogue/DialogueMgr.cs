using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMgr : MonoBehaviour
{
    // Dialogue Manager is responsible for delegating
    // all of the tasks related to the Dialogue system.
    // It takes the dialogue "lines" from the DialogueTrigger
    // class and takes the wheel from then on.
    public Queue<DialogueLine> dialogueLines { get; private set; }
    private bool dialogueActive;
    private bool isFinal;
    private UIUpdater uiUpdater;
    private StateManager stateManager;
    private ExternalTriggers externalTriggers;
    private AudioSource audioSource;

    void Start()
    {
        dialogueLines = new Queue<DialogueLine>();
        audioSource = GetComponent<AudioSource>();
        uiUpdater = GetComponent<UIUpdater>();
        stateManager = GetComponent<StateManager>();
        externalTriggers = GetComponent<ExternalTriggers>();
    }

    void Update()
    {
        // Do not update the Dialogue if people press Submit
        // (Yellow button). This is because, when we were 
        if (dialogueActive == false || Input.GetButtonDown("Submit")) return;
        if (Input.anyKeyDown)
        {
            ShowNextLine();
        }
    }

    public void StartDialogue(DialogueLine[] lines, bool final)
    {
        stateManager.TogglePlayerBlock(true);
        stateManager.TogglePauseMenuBlock(true);
        uiUpdater.ShowDialogue();
        dialogueLines.Clear();
        dialogueActive = true;
        isFinal = final;
        foreach (DialogueLine line in lines)
        {
            dialogueLines.Enqueue(line);
        }
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = dialogueLines.Dequeue();
        uiUpdater.UpdateDialogueUI(currentLine, audioSource);
    }

    public void EndDialogue()
    {
        dialogueActive = false;
        uiUpdater.HideDialogue();
        stateManager.TogglePlayerBlock(false);
        externalTriggers.HandleEndOfDialogue(isFinal);
        stateManager.TogglePauseMenuBlock(false);
        
        // Block the Pause menu briefly in case the player
        // is using the yellow button to proceed
        // with the dialogue. (Without this block,)
        // they would get a pause screen at the end of
        // the dialogue, and it was a bit awkward.
        stateManager.BlockPauseMenuBriefly();
    }
}
