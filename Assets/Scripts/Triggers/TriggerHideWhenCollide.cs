using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hides gameobjects

public class TriggerHideWhenCollide : MonoBehaviour 
{
    public GameObject[] gameObjectsToHide;

    private void Start() {
        
    }


    private void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            for (int i = 0; i < gameObjectsToHide.Length; i++) {
                gameObjectsToHide[i].SetActive(false);
            }
        }
    }
}
