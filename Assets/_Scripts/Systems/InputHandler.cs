using System;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public static event Action<Vector3> OnJoystickMove;

    private bool isActive = false;

    [SerializeField]
    private FloatingJoystick joystick;

    private Vector3 _direction = Vector3.zero;

    // Update is called once per frame
    void Update() {
        if (!isActive) return;

        CalculateInput();
    }
    void FixedUpdate() {
        if (!isActive) return;

        OnJoystickMove?.Invoke(_direction);

    }

    void CalculateInput() {
        _direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
    }

    public void SetIsActive(bool v) {
        isActive = v;
        joystick.gameObject.SetActive(v);
    }
}
