using UnityEngine;

public class Obstacle : MonoBehaviour {
    [SerializeField]
    private bool isHarmful;

    [SerializeField]
    private float force;


    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Enemy")) {

            var character = collision.collider.GetComponent<Character>();


            if (collision.collider.CompareTag("Enemy")) {
                ((Enemy)character).PushBack(collision.contacts[0].point, force);

                if (isHarmful) {
                    ((Enemy)character).Die();
                }
            } else {
                character.PushBack(collision.contacts[0].point, force);

                if (isHarmful) {
                    ((Player)character).Die();
                }
            }


        }
    }
}
