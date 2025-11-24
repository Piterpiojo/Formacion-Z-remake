using UnityEngine;

public class EnemigoPunto : MonoBehaviour
{
    [Header("Configuración de Puntos")]
    [SerializeField] private float puntosQueDa = 10f; 
    private Puntaje puntaje; 

    private void Awake()
    {
        puntaje = FindObjectOfType<Puntaje>();
    }

    public void DarPuntos()
    {
        if (puntaje != null)
        {
            puntaje.SumarPuntos(puntosQueDa);
        }
    }
}
