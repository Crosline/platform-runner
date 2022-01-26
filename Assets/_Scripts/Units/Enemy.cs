using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Character {

    [SerializeField]
    private Transform _enemyPath;

    [SerializeField]
    private Transform _finalDestination;

    private Vector3 _destination;

    private List<Vector3> _path = new List<Vector3>();
    private int _counter = 0;

    [SerializeField]
    private NavMeshAgent _navMeshAgent;

    //private Vector3 _destination;

    void OnEnable() {
        if (_navMeshAgent == null)
            _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        _animator.SetFloat("Speed", _navMeshAgent.velocity.magnitude);


        if (_navMeshAgent.remainingDistance < 1f) {


            if (_counter == _path.Count) {
                _navMeshAgent.SetDestination(_destination);
            } else if (_counter < _path.Count) {
                _navMeshAgent.SetDestination(_path[_counter]);
                _counter++;
            } else {
                _navMeshAgent.isStopped = true;
                _navMeshAgent.velocity = Vector3.zero;
            }

        }
    }

    public void Init() {

        for (int i = 0; i < _enemyPath.childCount; i++) {

            _path.Add(_enemyPath.GetChild(i).position);

        }
        if (_finalDestination == null) {
            _finalDestination = transform.GetChild(3);
        }
        _destination = _finalDestination.position;
        //_destination = destination;
        //_navMeshAgent.SetDestination(_destination);
        _navMeshAgent.SetDestination(_path[_counter]);
        _counter++;
        _navMeshAgent.speed = _speed;
    }

    public new void Die() {
        StartCoroutine(RestartCheckpoint());
    }


    public new void PushBack(Vector3 hitPoint, float force) {

        Vector3 dir = (transform.position - hitPoint).normalized;

        _navMeshAgent.velocity = (dir * force);
    }

    IEnumerator RestartCheckpoint() {
        if (_canMove) {
            _canMove = false;

            yield return new WaitForSeconds(.1f);

            _rb.velocity = Vector3.zero;
            _navMeshAgent.Warp(_startPos);
            //_navMeshAgent.SetDestination(_destination);

            _counter = 0;
            _navMeshAgent.SetDestination(_path[_counter]);
            _counter++;

            _canMove = true;
        }


    }

}
