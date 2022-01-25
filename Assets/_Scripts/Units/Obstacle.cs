using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private bool isHarmful;

    [SerializeField]
    private float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Enemy")) {


            Vector3 dir = (transform.position - collision.GetContact(0).point).normalized;

            Rigidbody r = collision.collider.GetComponent<Rigidbody>();

            r.AddForce(collision.contacts[0].normal * force);
        }
    }
}
