using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaVictoria : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputNombre; 
    [SerializeField] private TextMeshProUGUI textoFinal;

    private Puntaje puntaje;

    private void Start()
    {
        puntaje = FindObjectOfType<Puntaje>();

        if (puntaje != null && textoFinal != null)
        {
            textoFinal.text = "Tu puntaje final: " + puntaje.GetPuntos().ToString("0");
        }
    }

    public void GuardarPuntaje()
    {
        if (puntaje != null && inputNombre != null)
        {
            string nombreJugador = inputNombre.text;
            float puntosFinales = puntaje.GetPuntos();

            int total = PlayerPrefs.GetInt("TotalJugadores", 0);

            PlayerPrefs.SetString("Jugador_" + total, nombreJugador);
            PlayerPrefs.SetFloat("Puntaje_" + total, puntosFinales);

            PlayerPrefs.SetInt("TotalJugadores", total + 1);

            PlayerPrefs.Save();

            Debug.Log("Guardado: " + nombreJugador + " - " + puntosFinales);
        }
    }
    public void CambiarEscena()
    {
        SceneManager.LoadScene("Menu");
    }
}