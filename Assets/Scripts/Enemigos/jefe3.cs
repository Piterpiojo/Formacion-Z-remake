using System.Collections;
using UnityEngine;

public class jefe3 : MonoBehaviour
{
    [SerializeField] Transform[] posiciones;
    [SerializeField] float tiempoCambio;

    [SerializeField] GameObject[] mira;

    [SerializeField] GameObject prefab;
    void Start()
    {
        StartCoroutine(Tiempo(tiempoCambio));
    }


    void cambiarPosicion(int posicion)
    {
        transform.position = posiciones[posicion].position;
        StartCoroutine(Tiempo(tiempoCambio));
        rafaga();
    }


    IEnumerator Tiempo(float segundos)
    {

        yield return new WaitForSeconds(segundos);
        int posicion = Random.Range(0, posiciones.Length);
        cambiarPosicion(posicion);
    }


    void rafaga(){
        for (int i = 0; i < 8; i++)
        {
            StartCoroutine(disparoTiempo(0.2f * i));
        }
    }

    void disparar()
    {
        int miraElegida = Random.Range(0, mira.Length);
        Destroy(Instantiate(prefab, mira[miraElegida].transform.position, Quaternion.identity), 2f);
    }

    IEnumerator disparoTiempo(float segundos)
    {

        yield return new WaitForSeconds(segundos);
        disparar();
    }
}
