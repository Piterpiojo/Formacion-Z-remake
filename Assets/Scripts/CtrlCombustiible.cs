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
    bool EsRobot = false;
    float maxCombustible = 99f;
    Coroutine consumo;


    void Start()
    {
        Texto.text =combustible.ToString("00");

        

    }
private void OnEnable() {
            if (!EsRobot)
        {
            
           consumo = StartCoroutine("Consumo");
        }
}

private void OnDisable() {
    if (consumo != null)
    {
        StopCoroutine(consumo);
    }
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

    public void Recargar(int cantidad){
        if (combustible < maxCombustible){
            combustible += cantidad;
        }
    }

}
