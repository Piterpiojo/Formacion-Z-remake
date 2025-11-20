using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class SeguidorEnemigo : MonoBehaviour
{
    AudioSource audio;
    SplineAnimate spline;

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
