using System;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _smooth;

    [SerializeField]
    private Vector3 _offset;

    [SerializeField]
    private Quaternion _rotation;

    [SerializeField]
    private bool _canMove = false;

    void OnEnable() {
        GameManager.OnAfterStateChanged += StartMove;
    }

    void OnDisable() {
        GameManager.OnAfterStateChanged -= StartMove;
    }

    // Start is called before the first frame update
    void Start() {
        _offset = transform.position - _target.position;
        _rotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (!_canMove) return;

        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _smooth * Time.fixedDeltaTime);
    }

    private void StartMove(GameManager.GameState gameState) {

        if (gameState == GameManager.GameState.Running) {
            _canMove = true;
        } else if (gameState == GameManager.GameState.Painting) {
            SetTarget(_target, new Vector3(0, 5, 1), Quaternion.identity);
        }
    }

    public void SetOffset(Vector3 offset, Quaternion rotation) {
        _offset = offset;
        _rotation = rotation;
    }

    public void SetTarget(Transform target, Vector3 offset, Quaternion rotation) {
        _target = target;
        SetOffset(offset, rotation);
    }
}
