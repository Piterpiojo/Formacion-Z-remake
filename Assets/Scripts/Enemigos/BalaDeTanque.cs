using UnityEngine;

public class BalaDeTanque : MonoBehaviour
{
    Rigidbody rb;
    float velocidad = -10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
    }

    void Update()
    {
        rb.linearVelocity = transform.forward * velocidad;
    }
}
