using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones_UI : MonoBehaviour
{
    public void reintentar(){
        string scena = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scena);
    }

    public void salir(){
        Application.Quit();
    }
}
