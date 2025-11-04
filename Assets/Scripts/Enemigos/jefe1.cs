using System.Collections;
using UnityEngine;
public class jefe1 : MonoBehaviour
{
    [SerializeField] private GameObject[]  puntoDisparo;
    [SerializeField] private GameObject bala;

    [SerializeField] float min = 0.1f;
    [SerializeField] float max = 0.4f;
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
            yield return new WaitForSeconds(Random.Range(min, max));
        }
    }


    int disparos()
    {
        if (i < puntoDisparo.Length - 1)
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
