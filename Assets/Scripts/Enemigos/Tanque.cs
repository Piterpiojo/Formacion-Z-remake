using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanque : MonoBehaviour
{
    public GameObject bala;
    public Transform puntoDisparo;
    void Start()
    {
        StartCoroutine(Esperar());
    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(2);
        Disparar();
    }


    void Disparar(){
        Instantiate(  bala, puntoDisparo.position, puntoDisparo.rotation);
    }
}
