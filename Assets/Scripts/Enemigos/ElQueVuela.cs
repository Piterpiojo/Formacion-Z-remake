using UnityEngine;

public class ElQueVuela : MonoBehaviour
{
    Camera camera;
    Rigidbody rb;
    Vector3 posJugador;
    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody>(); 
        
        posJugador = camera.WorldToViewportPoint(GameManager.instancia.jugador.transform.position);
    }


    void Update()
    {
        Debug.Log(camera.WorldToViewportPoint(transform.position));
        Vector3 pos = camera.WorldToViewportPoint(transform.position);
        if (pos.x < posJugador.x)
        {
            rb.linearVelocity = new Vector3(-300f,600f,0) * Time.deltaTime;
        }else{
             rb.linearVelocity = new Vector3(-330f,0,0) * Time.deltaTime;
        }
    }



}
