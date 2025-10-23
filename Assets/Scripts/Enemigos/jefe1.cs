using System.Collections;
using UnityEngine;
public class jefe1 : MonoBehaviour
{
    [SerializeField] private GameObject[]  puntoDisparo;
    [SerializeField] private GameObject bala;
    int i = 0;
    void Start()
    {
        StartCoroutine(disparo());
    }

    void OnEnable()
    {
        StartCoroutine(disparo());
    }

    void crearBala()
    {
        Instantiate(bala, puntoDisparo[disparos()].transform.position, Quaternion.identity);
    }

    IEnumerator disparo()
    {
        while (true)
        {

            crearBala();
            yield return new WaitForSeconds(Random.Range(0.1f, .4f));
        }
    }


    int disparos()
    {
        if (i < 2)
        {
            i++;
        }
        else
        {
            i = 0;
        }
        return i;

    }
}
