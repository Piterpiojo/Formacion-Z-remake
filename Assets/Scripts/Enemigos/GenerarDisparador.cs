using UnityEngine;
using UnityEngine.Splines;
using System.Collections;


public class GenerarDisparador : MonoBehaviour
{

    public GameObject Enemigo;
    public SplineContainer[] patrones;


    void Start()
    {

        generar();
    }


    void generar()
    {
        int num = Random.Range(0, patrones.Length);
        GameObject enemigo = Instantiate(Enemigo, patrones[num].transform.position, Quaternion.identity);
        enemigo.GetComponent<SplineAnimate>().Container = patrones[num];
        enemigo.GetComponent<SplineAnimate>().Play();
        float rand = Random.Range(3, 17);
        
        StartCoroutine(esperar(rand));
    }

    IEnumerator esperar(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        generar();
    }
   
}
