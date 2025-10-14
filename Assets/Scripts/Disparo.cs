using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    Rigidbody rb;
    public List<GameObject> efect = new List<GameObject>();
    public float velocidad = 40f;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

        Destroy(gameObject, 0.7f);
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
            Destroy(Instantiate(efect[1], transform.position, Quaternion.identity), 1f);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("jefe"))
        {
            collision.gameObject.GetComponent<SaludEnemigo>().recibirDanio();
             Destroy(Instantiate(efect[0], transform.position, Quaternion.identity), 1f);
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            Destroy(other.gameObject);
             Destroy(Instantiate(efect[1], transform.position, Quaternion.identity), 1f);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("jefe"))
        {
            other.GetComponent<SaludEnemigo>().recibirDanio();
             Destroy(Instantiate(efect[0], transform.position, Quaternion.identity), 1f);
             Destroy(gameObject);
        }
    }


    void OnDestroy()
    {
        GameManager.instancia.balas -= 1;
    }
}
