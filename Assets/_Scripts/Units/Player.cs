using System;
using System.Collections;
using UnityEngine;

public class Player : Character {
    public static event Action OnRestartTriggered;

    void OnEnable() {

        InputHandler.OnJoystickMove += Move;
    }
    void OnDisable() {
        InputHandler.OnJoystickMove -= Move;
    }

    // Update is called once per frame
    void Update() {

    }

    private void Move(Vector3 dir) {
        if (!_canMove) {
            _animator.SetFloat("Speed", 0f);
            return;
        }
        _animator.SetFloat("Speed", dir.magnitude);

        if (dir.magnitude > 0.08f) {


            transform.forward = dir.normalized;

            if (dir.magnitude < 0.6f) {
                dir = dir.normalized;
                dir *= 0.3f;
            } else {
                dir = dir.normalized;
            }

            dir *= _speed * Time.fixedDeltaTime;

            //_rb.velocity += new Vector3(dir.x, _rb.velocity.y, dir.z);

            //_rb.AddForce(dir, ForceMode.Impulse);

            //_rb.MovePosition(transform.position + dir);

            transform.position += dir;
        }




    }

    public new void Die() {
        StartCoroutine(RestartCheckpoint());
    }

    IEnumerator RestartCheckpoint() {
        _canMove = false;
        yield return new WaitForSeconds(.5f);

        _rb.velocity = Vector3.zero;
        transform.position = _startPos;

        OnRestartTriggered?.Invoke();
        _canMove = true;
        StopAllCoroutines();
    }

}
