using UnityEngine;

public class ElQueVuela : MonoBehaviour
{
    Camera camera;
    Rigidbody rb;
    Vector3 posJugador;

    [SerializeField]
    bool salta = true;
    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();

        posJugador = camera.WorldToViewportPoint(GameManager.instancia.jugador.transform.position);
        Destroy(gameObject, 4f);
    }


    void FixedUpdate()
    {
        Vector3 pos = camera.WorldToViewportPoint(transform.position);
        if (pos.x < posJugador.x && salta)
        {
            rb.linearVelocity = new Vector3(-300f,600f,0) * Time.deltaTime;
        }else{
             rb.linearVelocity = new Vector3(-330f,0,0) * Time.deltaTime;
        }
    }



}
