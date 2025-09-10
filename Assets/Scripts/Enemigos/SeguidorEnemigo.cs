using Unity.VisualScripting;
using UnityEngine;

public class SeguidorEnemigo : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 8f);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }
    }
}
