using UnityEngine;
using UnityEngine.Splines;
public class HongoDispara : MonoBehaviour
{
    public GameObject bala;
    public Transform puntoDisparo;
    SplineAnimate spline;
    public float max = 20;
    public float min = 10;

    void Start()
    {
        InvokeRepeating("Disparar", 2f, 2f); // Dispara cada 3 segundos después de un retraso inicial de 2 segundos
        spline = GetComponent<SplineAnimate>();
        float velocidad = Random.Range(min,max);
        spline.MaxSpeed=velocidad   ;
    }


    void Disparar()
    {
        Instantiate(bala, puntoDisparo.position, puntoDisparo.rotation);
    }
}
