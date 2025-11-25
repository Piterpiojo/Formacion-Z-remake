using UnityEngine;

public class EnemigoDisparo : MonoBehaviour
{
    [Header("Prefab de la bala")]
    public GameObject balaOmega;

    [Header("Punto de salida")]
    public Transform puntoDisparo;

    [Header("Disparo autom�tico")]
    public float intervaloDisparo = 2f;
    public float velocidadBala = 20f;

    private float temporizador;
    private Transform objetivo;

    private void Start()
    {
        temporizador = intervaloDisparo;

        // Buscar al jugador por tag
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            objetivo = jugador.transform;
        }
        else
        {
            Debug.LogWarning("No se encontr� el jugador con tag 'Player'");
        }
    }

    private void Update()
    {
        if (objetivo == null) return;

        temporizador -= Time.deltaTime;
        if (temporizador <= 0f)
        {
            DispararBala();
            temporizador = intervaloDisparo;
        }
    }

    private void DispararBala()
    {
        Instantiate(balaOmega, puntoDisparo.position, puntoDisparo.rotation);
    }
}