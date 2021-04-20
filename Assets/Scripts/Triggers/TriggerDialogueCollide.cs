using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogueCollide : MonoBehaviour 
{
    public bool triggerOnce = true;
    public Dialogue dialogueToUse;

    private DialogueManager dialogueManager;
    private bool isTriggered = false;

    private void Start() {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }


    private void OnTriggerEnter(Collider other) {
        if (other.tag != "Player") return;

        if (!isTriggered) {
            dialogueManager.TriggerDialogue(dialogueToUse);
            isTriggered = triggerOnce;
        }
    }
}
