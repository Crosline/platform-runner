using System;
using UnityEngine;

public class Test : MonoBehaviour {
    public float speed;
    public float jumpForce;

    public Animator animator;

    public LayerMask groundMask;

    private Rigidbody rb;

    private bool IsGrounded {
        get {
            return Physics.SphereCast(new Ray(transform.position, transform.up * -1f), 0.3f , 1f, groundMask);
        }
    }

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();

    }

}
