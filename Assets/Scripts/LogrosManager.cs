using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogrosManager : MonoBehaviour
{
    [Header("UI Notificación")]
    [SerializeField] private GameObject panelLogro; // Panel lateral estilo Steam
    [SerializeField] private TextMeshProUGUI textoLogro;

    private int[] umbrales = { 1000, 5000, 10000, 20000, 30000 };

    private Puntaje puntaje;
    private bool[] desbloqueados;

    private void Start()
    {
        puntaje = FindObjectOfType<Puntaje>();
        desbloqueados = new bool[umbrales.Length];

        if (panelLogro != null)
            panelLogro.SetActive(false);
    }

    private void Update()
    {
        if (puntaje == null) return;

        float puntosActuales = puntaje.GetPuntos();

        for (int i = 0; i < umbrales.Length; i++)
        {
            if (!desbloqueados[i] && puntosActuales >= umbrales[i])
            {
                desbloqueados[i] = true;
                MostrarLogro("¡Logro desbloqueado! " + umbrales[i] + " puntos");
            }
        }
    }

    private void MostrarLogro(string mensaje)
    {
        if (panelLogro != null && textoLogro != null)
        {
            textoLogro.text = mensaje;
            panelLogro.SetActive(true);

            CancelInvoke();
            Invoke("OcultarLogro", 5f);
        }
    }

    private void OcultarLogro()
    {
        if (panelLogro != null)
            panelLogro.SetActive(false);
    }

    public void ResetearLogros()
    {
        for (int i = 0; i < desbloqueados.Length; i++)
        {
            desbloqueados[i] = false;
        }

        if (panelLogro != null)
            panelLogro.SetActive(false);

        Debug.Log("Reiniciado");
    }
    public void VolverAlMenu()
    {
        ResetearLogros();
        SceneManager.LoadScene("Menu");

    }
}
