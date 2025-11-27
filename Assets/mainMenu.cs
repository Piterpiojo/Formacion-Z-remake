using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("NivelActual", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarEscena()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SalirJuego()
    {
        Application.Quit();
    }
}
