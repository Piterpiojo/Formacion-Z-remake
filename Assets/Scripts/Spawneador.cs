using UnityEngine;
using System.Collections;

public class Spawneador : MonoBehaviour
{
    public GameObject cosa;
    public GameObject SubeYbaja;
    public GameObject terreno;
    void Start()
    {
         StartCoroutine("tiempo");
    }

    void Update()
    {
       

    }


    IEnumerator tiempo(){
        yield return new WaitForSeconds(7f);    
        Instantiate(cosa,transform.position,Quaternion.identity);
        StartCoroutine("tiempo");
    }
}
