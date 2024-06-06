using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    // The UIUpdater class is responsible
    // for updating all the UI elements
    // related to the Dialogue.
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI lineText;
    public Image headshotDisplay;
    public Sprite maggieSprite;
    public Sprite playerSprite;
    public Animator animator;

    public void ShowDialogue()
    {
        animator.SetBool("IsOpen", true);
    }

    public void HideDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    public void UpdateDialogueUI(DialogueLine currentLine, AudioSource audioSource)
    {
        nameText.text = currentLine.name;
        SetCharacterHeadshot(currentLine.name);
        StopAllCoroutines();
        StartCoroutine(TypeLine(currentLine.line, audioSource));
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

    IEnumerator TypeLine(string line, AudioSource audioSource)
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

        // Stop playing the typing sound
        // once the line has been typed out.
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
