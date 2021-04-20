using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteHero : MonoBehaviour 
{
    public int damage;


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            other.GetComponentInParent<Hero>().Damage(damage);
        }
    }
}
