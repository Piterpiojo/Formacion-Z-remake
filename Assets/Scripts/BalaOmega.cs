using System.Collections.Generic;
using UnityEngine;

public class BalaOmega : MonoBehaviour
{
    public float velocidad = 5f;          
    public float tiempoVida = 10f;       
    [Header("Explosión")]
    public GameObject balaFragmentoPrefab; 
    public int cantidadFragmentos = 10;   
    public float fuerzaFragmentos = 15f;

    [Header("Referencia directa a la bala del jugador")]
    public GameObject balaDelJugadorPrefab;

    private Transform objetivo;

    private void Start()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            objetivo = jugador.transform;
        }

        Destroy(gameObject, tiempoVida);
    }

    private void Update()
    {
        if (objetivo == null) return;

        Vector3 direccion = (objetivo.position - transform.position).normalized;
        transform.position += direccion * velocidad * Time.deltaTime;
    }

    // Cuando recibe un disparo del jugador
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.name.Contains(balaDelJugadorPrefab.name))
        {
           Explota(other.gameObject); 
           Destroy(other.gameObject); 
        }
     }

    private void Explota(GameObject balaQueDisparo = null)
    {
        Collider colOriginal = GetComponent<Collider>();
        List<Collider> fragmentosColliders = new List<Collider>();

        for (int i = 0; i < cantidadFragmentos; i++)
        {
            GameObject frag = Instantiate(balaFragmentoPrefab, transform.position, Quaternion.identity);

            Collider colFragmento = frag.GetComponent<Collider>();
            if (colOriginal != null && colFragmento != null)
                Physics.IgnoreCollision(colOriginal, colFragmento);

            if (balaQueDisparo != null)
            {
                Collider colBalaJugador = balaQueDisparo.GetComponent<Collider>();
                if (colBalaJugador != null && colFragmento != null)
                    Physics.IgnoreCollision(colBalaJugador, colFragmento);
            }

            foreach (Collider colPrevio in fragmentosColliders)
                Physics.IgnoreCollision(colPrevio, colFragmento);
            fragmentosColliders.Add(colFragmento);

            Rigidbody rb = frag.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Dirección aleatoria en X–Y
                float x = Random.Range(-1f, 1f);
                float y = Random.Range(-1f, 1f);
                Vector3 direccionAleatoria = new Vector3(x, y, 0).normalized;

                // Posición inicial con Z fijo en 12
                frag.transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    12f // Z fijo
                );

                rb.linearVelocity = direccionAleatoria * fuerzaFragmentos;
            }
        }

        Destroy(gameObject);
    }

}
