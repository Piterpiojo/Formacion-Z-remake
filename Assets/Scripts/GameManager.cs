using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject jugador;
    public static GameManager instancia ;

    public ElFondoScroll fondo;

    void Awake()
    {
                instancia = this;
    }
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");

    }

    public void Velocidad(float cantidad)
    {
        fondo.velocidad = cantidad;
    }
}
