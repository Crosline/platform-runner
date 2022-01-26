using System;
using UnityEngine;

public class Finish : MonoBehaviour {

    public static event Action<Transform> OnFinishedEvent;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.transform.position = transform.position;
            other.attachedRigidbody.isKinematic = true;
            OnFinishedEvent?.Invoke(other.transform);
            GameManager.Instance.ChangeState(GameManager.GameState.Painting);
        } else if (other.CompareTag("Enemy")) {
            other.enabled = false;
            OnFinishedEvent?.Invoke(other.transform);
        }
    }
}
