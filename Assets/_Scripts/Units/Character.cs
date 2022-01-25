using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Character : MonoBehaviour, ICharacter
{
    private Vector3 _startPos;

    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        if (_rb == null)
            _rb = GetComponent<Rigidbody>();
        _startPos = transform.position;
    }

    public void Die() {
        StopAllCoroutines();
        StartCoroutine(RestartCheckpoint());
    }
    public void Move() {
        throw new System.NotImplementedException();
    }

    IEnumerator RestartCheckpoint() {
        yield return new WaitForSeconds(1f);

        _rb.velocity = Vector3.zero;
        transform.position = _startPos;

    }

}
