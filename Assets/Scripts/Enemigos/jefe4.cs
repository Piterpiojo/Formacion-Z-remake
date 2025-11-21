using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class jefe4 : MonoBehaviour
{
    [SerializeField] SplineContainer[] movimiento;
    [SerializeField] GameObject PosInicial;
    SplineAnimate spline;
    void Start()
    {
        VolverAPosicionInicial();
        spline = GetComponent<SplineAnimate>();
        int indice = Random.Range(0, movimiento.Length);
        spline.Container = movimiento[indice];
        spline.Play();
    }


    void Update()
    {
        if (spline.Duration - spline.ElapsedTime < 0.1f && spline.IsPlaying)
        {
            finalizarMovimiento();
        }
    }

    void finalizarMovimiento()
    {
  
        spline.Pause();
        VolverAPosicionInicial();
        StartCoroutine(esperar(3f));

    }

    void VolverAPosicionInicial()
    {
        transform.position = PosInicial.transform.position;
        transform.rotation = PosInicial.transform.rotation;
    }

    IEnumerator esperar(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        int indice = Random.Range(0, movimiento.Length);
        spline.Restart(true);
        spline.Container = movimiento[indice];
        spline.Play();
    }
}
