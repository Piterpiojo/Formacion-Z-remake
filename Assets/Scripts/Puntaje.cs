using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;

    private static Puntaje instancia;

    private void Awake()
    {
        // Singleton para mantener un único puntaje
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;
        DontDestroyOnLoad(gameObject);

        // Cargar puntaje guardado al iniciar
        puntos = PlayerPrefs.GetFloat("ScoreJugador", 0);
    }

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        // Solo suma puntos si no estamos en la pantalla de victoria
        if (SceneManager.GetActiveScene().name != "pantalla de victoria")
        {
            puntos += Time.deltaTime;
        }

        // Actualiza el texto siempre
        if (textMesh != null)
            textMesh.text = puntos.ToString("0");

        // Guardar continuamente el puntaje
        PlayerPrefs.SetFloat("ScoreJugador", puntos);
    }

    public void SumarPuntos(float puntosEntrando)
    {
        puntos += puntosEntrando;
        PlayerPrefs.SetFloat("ScoreJugador", puntos); // Guardar al sumar
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reinicia el puntaje solo si volvemos a la escena inicial (ejemplo: "menu")
        if (scene.name == "SampleScene")
        {
            puntos = 0;
            PlayerPrefs.SetFloat("ScoreJugador", puntos); // Guardar reinicio
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

