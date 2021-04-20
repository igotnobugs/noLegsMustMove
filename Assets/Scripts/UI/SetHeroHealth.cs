using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHeroHealth : MonoBehaviour 
{
    public Hero hero;
    public Text textHealth;

    private void Start() {
        
    }


    private void Update() {
        textHealth.text = "HP: " + hero.GetHeath().ToString();
    }
}
