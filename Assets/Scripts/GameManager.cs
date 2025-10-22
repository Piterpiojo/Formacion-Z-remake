using Unity.Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject jugador;
    public static GameManager instancia;

    public CinemachineCamera cam;

    public ElFondoScroll fondo;
    public int balas = 0;
    public bool volando = false;

    CtrlCombustiible ctrlCombustiible;

    void Awake()
    {
        instancia = this;
        ctrlCombustiible = GetComponent<CtrlCombustiible>();
    }
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");


    }

    public void Velocidad(float cantidad)
    {
        fondo.velocidad = cantidad;
    }

    public void CambiarObjetivo(Transform nuevoObjetivo)
    {
        cam.Follow = nuevoObjetivo;
    }

    public CtrlCombustiible GetCtrlCombustiible()
    {
        return ctrlCombustiible;
    }
}
