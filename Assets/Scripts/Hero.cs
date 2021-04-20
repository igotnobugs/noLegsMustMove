using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour 
{
    public int health = 3;

    public float invinsiblityTime = 2.0f;
    private float currentInviTime = 0.0f;

    public delegate void HeroEvent();
    public event HeroEvent OnDeath;

    private void Update() {
        if (currentInviTime > 0) {
            currentInviTime -= Time.deltaTime;
        }
    }

    public void Damage(int amount) {
        if (currentInviTime > 0) return;     
        health -= amount;      
        if (health <= 0) {
            OnDeath?.Invoke();
        }

        currentInviTime = invinsiblityTime;
    }

    public int GetHeath() {
        if (health < 0) return 0;
        return health;
    }
}
