using Unity.VisualScripting;
using UnityEngine;

public class SeguidorEnemigo : MonoBehaviour
{
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
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
