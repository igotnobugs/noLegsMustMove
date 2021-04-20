using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour 
{
    public float speed;
    public int damage = 9996;
    public ParticleSystem explosion;

    public GameObject targetAnimator;
    public GameObject target;

    public float radius = 5.0F;
    public float power = 10.0F;

    private void Start() {
        
    }


    private void Update() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);
        targetAnimator.GetComponent<Animator>().enabled = false;
        target.GetComponent<Rigidbody>().AddForce(Vector3.up * 100.0f, ForceMode.Impulse);

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
        target.GetComponentInParent<Hero>().Damage(damage);
        Destroy(gameObject);
           
    }


}
