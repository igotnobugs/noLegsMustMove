using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public Hero hero;
    public CameraControl cameraControl;
    public DialogueManager dialogueManager;
    public Dialogue introduction;
    public Dialogue tutorial;

    public GyroRotate gyroRotate;

    [Header("Game UI")]
    public GameObject[] gamePanels;

    private void Start() {
        ToggleGameUI(false);
        gyroRotate.enabled = false;

        dialogueManager.TriggerDialogue(introduction, () => {
            cameraControl.animator.SetBool("inFrontOfHero", false);
            dialogueManager.TriggerDialogue(tutorial);
            gyroRotate.enabled = true;
            ToggleGameUI(true);
        });

        hero.OnDeath += ResetGame;
    }

    private void ToggleGameUI(bool state) {
        for (int i = 0; i < gamePanels.Length; i++) {
            gamePanels[i].SetActive(state);
        }
    }

    private void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
