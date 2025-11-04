using UnityEngine;

public class BalaGuiada : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float velocidad = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        rb.linearVelocity = transform.forward * velocidad;
    }
}
