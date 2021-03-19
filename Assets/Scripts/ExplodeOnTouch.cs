using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnTouch : MonoBehaviour 
{

    public ParticleSystem explosion;

    private void Start() {
        
    }


    private void Update() {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.TryGetComponent(out Hero hero)) {
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
