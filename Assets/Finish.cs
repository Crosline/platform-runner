using UnityEngine;

public class Finish : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.transform.position = transform.position;
            GameManager.Instance.ChangeState(GameManager.GameState.Painting);
        }
    }
}
