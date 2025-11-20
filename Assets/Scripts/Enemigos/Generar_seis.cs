using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class Generar_seis : MonoBehaviour
{
    public GameObject Enemigo;
    public SplineContainer[] patrones;
    public float min= 4;
    public float max= 10;
    Coroutine generar6;

    void Start()
    {

        generar6 = StartCoroutine(generar());
    }


    IEnumerator generar()
    {
        int num = Random.Range(0, patrones.Length);
        float velocidad= generarVelocidad();
        for (int i = 0; i < 6; i++)
        {
            GameObject enemigo = Instantiate(Enemigo, patrones[num].transform.position, Quaternion.identity);
            enemigo.GetComponent<SplineAnimate>().Container = patrones[num];
            enemigo.GetComponent<SplineAnimate>().MaxSpeed = velocidad;
            enemigo.GetComponent<SplineAnimate>().Play();
            yield return new WaitForSeconds(0.2f);
        }
     float rand = Random.Range(3, 9);
        StartCoroutine(esperar(rand));
    }

    IEnumerator esperar(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        generar6 = StartCoroutine(generar());
    }

    float generarVelocidad(){
        float velocidad = Random.Range(min,max);
        return velocidad;       
    }

}
