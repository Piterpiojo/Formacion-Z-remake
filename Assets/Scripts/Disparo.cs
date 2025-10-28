using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    Rigidbody rb;
    public List<GameObject> efect = new List<GameObject>();
    public float velocidad = 40f;

    [SerializeField] GameObject sonidoPrefab;

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
            explosion();
            Destroy(collision.gameObject);
            animExpplosion();
            
            Destroy(gameObject,1);
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
            explosion();
            Destroy(other.gameObject);
            animExpplosion();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("jefe"))
        {
            other.GetComponent<SaludEnemigo>().recibirDanio();
            Destroy(Instantiate(efect[0], transform.position, Quaternion.identity), 1f);
            Destroy(gameObject);
        }
    }

    void animExpplosion()
    {
        int num = Random.Range(0, efect.Count);
        Destroy(Instantiate(efect[num], transform.position, Quaternion.identity), 1f);
    }
    void OnDestroy()
    {
        GameManager.instancia.balas -= 1;
    }

    void explosion()
    {
        Destroy(Instantiate(sonidoPrefab, transform.position, Quaternion.identity), 2.6f);
    }
}
