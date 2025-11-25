using UnityEngine;

public class balaExtra : MonoBehaviour
{
    public float tiempoVida = 5f;

    private void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Opcional: daño al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Impacto con el jugador");
        }

        Destroy(gameObject);
    }
}
