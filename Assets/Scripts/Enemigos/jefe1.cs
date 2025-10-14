using System.Collections;
using UnityEngine;
public class jefe1 : MonoBehaviour
{
    [SerializeField] private GameObject puntoDisparo;
    [SerializeField] private GameObject bala;

    void Start()
    {
        StartCoroutine(disparo());
    }



    void crearBala()
    {
        Instantiate(bala, puntoDisparo.transform.position, Quaternion.identity);
    }

    IEnumerator disparo()
    {
        while (true)
        {

            crearBala();
            yield return new WaitForSeconds(Random.Range(0.4f, 1.2f));
        }
    }
}
