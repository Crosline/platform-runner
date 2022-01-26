using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Character : MonoBehaviour, ICharacter {
    internal Vector3 _startPos;

    [SerializeField]
    internal Rigidbody _rb;

    [SerializeField]
    internal float _speed;

    [SerializeField]
    internal Animator _animator;

    internal bool _canMove = true;

    // Start is called before the first frame update
    void Start() {
        if (_rb == null)
            _rb = GetComponent<Rigidbody>();

        if (_animator == null)
            _animator = transform.GetChild(0).GetComponent<Animator>();

        _startPos = transform.position;
    }

    public void Move() {
        throw new System.NotImplementedException();
    }

    public void PushBack(Vector3 hitPoint, float force) {

        Vector3 dir = (transform.position - hitPoint).normalized;

        _rb.velocity = (dir * force);
    }

    public void Die() {
        StartCoroutine(RestartCheckpoint());
    }

    IEnumerator RestartCheckpoint() {
        yield return new WaitForSeconds(1f);

        _rb.velocity = Vector3.zero;
        transform.position = _startPos;

        StopAllCoroutines();
    }

}
