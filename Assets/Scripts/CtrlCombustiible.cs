using System.Collections;
using TMPro;
using UnityEngine;

public class CtrlCombustiible : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Texto;
    [SerializeField]
    float combustible = 99f;
    [SerializeField]
    float maxCombustible = 99f;
    Coroutine consumo;

    bool parar = false;
    void Start()
    {
        Texto.text = combustible.ToString("00");
    }

    public void deshabilitarConsumo()
    {
        if (consumo != null)
        {
            parar = true;
            StopCoroutine(consumo);
            consumo = null;

        }
    }


    public void inicarConsumo()
    {
        if (consumo == null)
        {
            parar = false;
            consumo = StartCoroutine("Consumo");

        }
    }

    public void detenerConsumo()
    {
        if (consumo != null)
        {
            StopCoroutine(consumo);
            parar = true;
        }
    }
    private void OnDisable()
    {
        detenerConsumo();
    }

    IEnumerator Consumo()
    {
        yield return new WaitForSeconds(0.6f);
        combustible -= 1f;

        Texto.text = combustible.ToString("00");
        if (combustible > 0f && !parar)
        {
            StartCoroutine("Consumo");
        }
        else if (combustible <= 0f)
        {
            gameObject.GetComponent<ControJugador>().vivo = false;
            gameObject.GetComponent<ControJugador>().FaltaCombustible();
        }


    }

    public void Recargar(int cantidad)
    {
        if (combustible < maxCombustible)
        {
            combustible += cantidad;
            Texto.text = combustible.ToString("00");
        }
    }

}
