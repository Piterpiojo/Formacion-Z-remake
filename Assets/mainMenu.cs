using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarEscena()
    {
        SceneManager.LoadScene("SampleScene");
    }
    //public void CambiarColor()
   // {

    //}
    public void SalirJuego()
    {
        Application.Quit();
    }
}
