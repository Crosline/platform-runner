using UnityEngine;

public class Test : MonoBehaviour {
    public float speed;
    public float jumpForce;

    public Animator animator;

    public LayerMask groundMask;

    public FloatingJoystick joystick;

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

    private void Update() {
        
        if (Input.GetButtonDown("Jump")) {

            if (IsGrounded) {

                animator.SetTrigger("Jump");

                rb.AddForce(transform.up * jumpForce);
            }

        }
    }

    void FixedUpdate() {

        Vector3 dir = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;

        animator.SetFloat("Speed", dir.magnitude);
        if (dir.magnitude > 0.1f) {

            transform.forward = dir.normalized;

            if (dir.magnitude < 0.5f) {
                dir = dir.normalized;
                dir *= 0.3f;
            } else {
                dir = dir.normalized;
            }
        }




        float _velSpeed = speed * Time.fixedDeltaTime;

        rb.velocity = new Vector3(dir.x * _velSpeed, rb.velocity.y, dir.z * _velSpeed);

    }
}
