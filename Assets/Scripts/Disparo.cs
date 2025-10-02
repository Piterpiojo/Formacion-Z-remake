using UnityEngine;

public class Disparo : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad = 40f;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

        Destroy(gameObject, 0.7f    );
    }

    void FixedUpdate()
    {
        rb.linearVelocity = transform.forward * velocidad;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }


    void OnDestroy()
    {
        GameManager.instancia.balas-=1;
    }
}
