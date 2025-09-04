using UnityEngine;
using System.Collections;

public class Spawneador : MonoBehaviour
{
    public GameObject enemigo;
    public float tiempoEntreSpawns = 5f;
    void Start()
    {

        StartCoroutine("tiempo");

       
    }



    IEnumerator tiempo()
    {
        yield return new WaitForSeconds(tiempoEntreSpawns);
        Instantiate(enemigo, transform.position,transform.rotation);
        StartCoroutine("tiempo");
    }



}
