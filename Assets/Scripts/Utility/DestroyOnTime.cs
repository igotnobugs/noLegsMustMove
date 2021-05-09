using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour 
{
    public float time = 1.0f;

    private void Start() {
        Destroy(gameObject, time);
    }
}
