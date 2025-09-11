using UnityEngine;

public class HongoDispara : MonoBehaviour
{
    public GameObject bala;
    public Transform puntoDisparo;

    void Start()
    {
        InvokeRepeating("Disparar", 2f, 2f); // Dispara cada 3 segundos después de un retraso inicial de 2 segundos
    }


    void Disparar()
    {
        Instantiate(bala, puntoDisparo.position, puntoDisparo.rotation);
    }
}
