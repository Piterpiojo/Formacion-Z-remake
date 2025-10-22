using UnityEngine;

public class aEllaLeGustaLaGasolina : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] bool EsRobot = false;
    float velocidad = -330f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);
        if (GameManager.instancia.volando)
        {
            velocidad = velocidad * 2;
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(velocidad, 0, 0) * Time.deltaTime;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instancia.GetCtrlCombustiible().Recargar(10);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instancia.GetCtrlCombustiible().Recargar(10);
            Destroy(gameObject);

        }
    }
}
