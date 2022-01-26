using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{

    [SerializeField]
    private float _force;

    private void Update() {
        transform.Rotate(transform.forward, _force * Time.deltaTime, Space.Self);
    }
    private void OnCollisionStay(Collision collision) {
        collision.collider.attachedRigidbody.velocity = Vector3.right * -1f * _force *10f * Time.deltaTime;
    }
}
