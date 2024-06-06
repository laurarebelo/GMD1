using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // DialogueManager is a big class. Too big.
    // It is DEPRECATED, and has been now broken down to:
    // DialogueMgr, ExternalTriggers, StateManager, UIUpdater
    public Queue<DialogueLine> dialogueLines;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI lineText;
    public Image headshotDisplay;
    public Sprite maggieSprite;
    public Sprite playerSprite;
    public PlayableDirector exitScene;

    public Animator animator;
    public PlayerBlocker playerGo;
    public SlimeSpawner slimeSpawner;
    public PauseMenu pauseMenu;
    private bool dialogueActive;
    private bool isFinal;
    private AudioSource audioSource;
    void Start()
    {
        dialogueLines = new Queue<DialogueLine>();
        audioSource = GetComponent<AudioSource>();
    }

    void TogglePlayerBlock(bool state)
    {
        if (playerGo != null)
        {
            playerGo.ToggleBlock(state);
        }
    }

    void TogglePauseMenuBlock(bool state)
    {
        if (pauseMenu != null)
        {
            pauseMenu.TogglePauseBlock(state);
        }
    }

    void Update()
    {
        if (dialogueActive == false || Input.GetButtonDown("Submit")) return;
        if (Input.anyKeyDown)
        {
            ShowNextLine();
        }
    } 

    public void StartDialogue(DialogueLine[] lines, bool final)
    {
        TogglePlayerBlock(true);
        TogglePauseMenuBlock(true);
        animator.SetBool("IsOpen", true);
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
        nameText.text = currentLine.name;
        SetCharacterHeadshot(currentLine.name);
        StopAllCoroutines();
        StartCoroutine(TypeLine(currentLine.line));
    }

    private void SetCharacterHeadshot(string charName)
    {
        switch (charName)
        {
            case "???":
                case "Maggie":
                    headshotDisplay.sprite = maggieSprite;
                    break;
            case "You":
                headshotDisplay.sprite = playerSprite;
                break;
        }
    }

    IEnumerator TypeLine(string line)
    {
        // Start playing the typing sound
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        lineText.text = string.Empty;
        foreach (char letter in line)
        {
            lineText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
        
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void EndDialogue()
    {
        dialogueActive = false;
        animator.SetBool("IsOpen", false);
        TogglePlayerBlock(false);
        if (exitScene != null && isFinal)
        {
            exitScene.Play();
        }

        if (slimeSpawner != null)
        {
            slimeSpawner.SpawnNext();
        }
        TogglePauseMenuBlock(false);
    }
}
