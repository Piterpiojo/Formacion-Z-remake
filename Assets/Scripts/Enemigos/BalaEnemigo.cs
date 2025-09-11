using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{

    private void Start() {
        Destroy(gameObject, 8f);
    }

    private void OnCollisionEnter(Collision other) {
                if (other.gameObject.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
                        if (other.gameObject.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }
    }
}
