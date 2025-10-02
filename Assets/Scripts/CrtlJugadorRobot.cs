using System.Collections;
using UnityEngine;

public class CrtlJugadorRobot : MonoBehaviour
{
    InputSystem_Actions controles;
    public Vector2 direcciones;
    public GameObject balaPrefab;
    Rigidbody rb;

    public GameObject avion;

    float limiteX = 60f;
    float limitey = 0.2f;
    public GameObject puntoDisparo;

    public bool vivo = true;

    Animator anim;
    public float velocidad = 25f;
    void Awake()
    {
        controles = new InputSystem_Actions();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    void OnEnable()
    {
        GameManager.instancia.Velocidad(-5f);
        GameManager.instancia.CambiarObjetivo(transform);
        controles.Enable();
        controles.Player.Attack.performed += ctx => disparar();
        controles.Player.Jump.performed += ctx => saltar();
        controles.Player.Transformar.performed += ctx => transformar();

    }

    void OnDisable()
    {
        controles.Disable();
    }


    void Update()
    {
        direcciones = controles.Player.Move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if (!vivo) return;
        if (transform.position.y > limiteX)
        {
            direcciones.y = -1;
        }
        Vector2 dir = new Vector2(direcciones.x, 0);

        rb.AddForce(dir.normalized * velocidad, ForceMode.Impulse);
        controlarApuntado(direcciones.y);
    }
    void    disparar()
    {
        if (GameManager.instancia.balas <3){
            Instantiate(balaPrefab, puntoDisparo.transform.position + puntoDisparo.transform.forward * 2, puntoDisparo.transform.rotation);
            GameManager.instancia.balas+=1;
        }
       
    }
    void saltar()
    {
        if (transform.position.y < limitey)
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }

    void controlarApuntado(float y)
    {
        if (y > 0.1f)
        {
            anim.SetBool("arriba", true);
            anim.SetBool("abajo", false);
        }
        else if (y < -0.1f)
        {
            anim.SetBool("arriba", false);
            anim.SetBool("abajo", true);
        }
        else
        {
            anim.SetBool("arriba", false);
            anim.SetBool("abajo", false);
        }
    }

    void transformar()
    {

        anim.SetTrigger("transformar");
        GameManager.instancia.volando = true;
        StartCoroutine("EsperarTransformacion");

    }

    IEnumerator EsperarTransformacion()
    {
        yield return new WaitForSeconds(1f);
        avion.SetActive(true);
        avion.transform.position = transform.position;
        gameObject.SetActive(false);
    }

    void  OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Enemigo"){
            GestionVida.instancia.recibir_danio(1); 
        }
    }
}