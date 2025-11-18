using UnityEngine;
using UnityEngine.Splines;
using System.Collections;


public class GenerarDisparador : MonoBehaviour
{
    [SerializeField] float min = 7f;
    [SerializeField] float max = 17f;
    [SerializeField] float primerEnemigo = 20f;
    public GameObject Enemigo;
    public SplineContainer[] patrones;


    void Start()
    {

        StartCoroutine(esperar(primerEnemigo ));
    }


    void generar()
    {
        int num = Random.Range(0, patrones.Length);
        GameObject enemigo = Instantiate(Enemigo, patrones[num].transform.position, Quaternion.identity);
        enemigo.GetComponent<SplineAnimate>().Container = patrones[num];
        enemigo.GetComponent<SplineAnimate>().Play();
        float rand = Random.Range(min, max);
        
        StartCoroutine(esperar(rand));
    }

    IEnumerator esperar(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        generar();
    }
   
}
