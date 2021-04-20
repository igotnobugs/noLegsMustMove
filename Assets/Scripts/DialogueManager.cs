using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogueManager : MonoBehaviour 
{

    public Dialogue dialogueToUse;
    public GameObject dialoguePanel;
    public Text textArea;

    private Queue<Script> scripts;
    private Action onCompleteFunc;

    private bool isCountingDown = false;
    private float dialogueTime;

    private void Awake() {
        scripts = new Queue<Script>();
    }

    private void Update() {
        if (isCountingDown) {
            if (dialogueTime > 0) {
                dialogueTime -= Time.deltaTime;
            } else {
                isCountingDown = false;
                DisplayNextSentence();            
            }
        }
    }

    public void StartDialogue(Dialogue dialogue, Action onCompleteFunc = null) {
        scripts.Clear();

        foreach (Script script in dialogue.scripts) {
            scripts.Enqueue(script);
        }

        this.onCompleteFunc = onCompleteFunc;
        dialoguePanel.SetActive(true);
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (scripts.Count == 0) {
            EndDialogue();
            return;
        }

        Script script = scripts.Dequeue();
        textArea.text = script.sentence;     
        dialogueTime = script.time;
        isCountingDown = true;
    }

    void EndDialogue() {
        dialoguePanel.SetActive(false);
        scripts.Clear();
        onCompleteFunc?.Invoke();
    }

    public void TriggerDialogue(Dialogue dialogue, Action onCompleteFunc = null) {
        dialogueToUse = dialogue;
        StartDialogue(dialogue, onCompleteFunc);
    }
}
