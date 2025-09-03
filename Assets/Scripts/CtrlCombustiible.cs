using System.Collections;
using TMPro;
using UnityEngine;

public class CtrlCombustiible : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Texto;
     [SerializeField]
    float combustible = 99f;
    float maxCombustible = 99f;

    void Start()
    {
        Texto.text =combustible.ToString("00");
        StartCoroutine("Consumo");
    }


    IEnumerator Consumo()
    {
        yield return new WaitForSeconds(0.5f);
        combustible -= 1f;

        Texto.text = combustible.ToString("00");
        if (combustible > 0f)
        {
            StartCoroutine("Consumo");
        }
        else
        {
            gameObject.GetComponent<ControJugador>().vivo = false;
            gameObject.GetComponent<ControJugador>().FaltaCombustible();
        }
        
        
    }

}
