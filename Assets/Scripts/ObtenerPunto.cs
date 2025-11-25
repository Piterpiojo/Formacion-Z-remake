using UnityEngine;


public class ObtenerPunto : MonoBehaviour
{
    [Header("Configuración de Puntos")]
    [SerializeField] private float cantidadPuntos = 10f; 
    [SerializeField] private Puntaje puntaje;           

    [Header("Configuración de Enemigo")]
    [SerializeField] private string tagEnemigo = "Enemigo";

    private void OnDestroy()
    {
        if (CompareTag(tagEnemigo) && puntaje != null)
        {
            puntaje.SumarPuntos(cantidadPuntos);
        }
    }
}
