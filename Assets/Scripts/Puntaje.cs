using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;

    private static Puntaje instancia;

    [Header("Configuración de Velocidad")]
    [SerializeField] private float velocidadConteo = 1f;
 
    private void Awake()
    {
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;
        DontDestroyOnLoad(gameObject);

        puntos = PlayerPrefs.GetFloat("ScoreJugador", 0);
    }
    public float GetPuntos()
    {
        return puntos;
    }

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        
        if (SceneManager.GetActiveScene().name != "Pantalla de victoria")
        {
            puntos += Time.deltaTime * velocidadConteo;
        }

       
        if (textMesh != null)
            textMesh.text = puntos.ToString("0");

       
        PlayerPrefs.SetFloat("ScoreJugador", puntos);
    }

    public void SumarPuntos(float puntosEntrando)
    {
        puntos += puntosEntrando;
        PlayerPrefs.SetFloat("ScoreJugador", puntos); 
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            puntos = 0;
            PlayerPrefs.SetFloat("ScoreJugador", puntos); 
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

