using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [SerializeField] GameObject panelPausa;
    InputSystem_Actions controles;
    void Awake()
    {
        controles = new InputSystem_Actions();
        controles.Enable();
        controles.UI.Cancel.performed += ctx => activarPausa();


    }


    public void activarPausa(){
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void desactivarPausa(){
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void VolverAPrincipal()
    {
        SceneManager.LoadScene(0);
    }
}
