using TMPro;
using UnityEngine;

public class GestionVida : MonoBehaviour
{
    public static GestionVida instancia;
    public GameObject PantallaDerrota;
    TextMeshProUGUI text;
    void Start()
    {
        instancia = this;
        text = GetComponent<TextMeshProUGUI>();
    }


    int vida = 3;


    public void recibir_danio(int cantidad)
    {
        vida -= 1;
        actualizar();
        if (vida < 1)
        {
            perder();
        }
    }
    void perder()
    {
        PantallaDerrota.SetActive(true);
    }
    void actualizar()
    {
        text.text = $"{vida}";
    }
}
