using UnityEngine;

public class Disparo : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad = 40f;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

        Destroy(gameObject, 1);
    }

    void FixedUpdate()
    {
        rb.linearVelocity= transform.forward * velocidad;
    }
}
