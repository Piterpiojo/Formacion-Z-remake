using System.Collections;
using UnityEngine;

public class Canion : MonoBehaviour
{
    [SerializeField] GameObject balaPrefab;
    [SerializeField] Transform puntoDisparo;

    [SerializeField] float tiempoEntreDisparos = 2f;

    void Start()
    {
      StartCoroutine(EsperarYDisparar(2f));  
    }

    void Disparar()
    {
        Destroy(Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation), 5f);
        Debug.Log("Disparo");
    }
    

    IEnumerator EsperarYDisparar(float segundos)
    {

        yield return new WaitForSeconds(segundos);
        Disparar();
        StartCoroutine(EsperarYDisparar(tiempoEntreDisparos));
    }
}
