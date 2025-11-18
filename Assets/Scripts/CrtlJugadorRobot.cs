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

    AudioSource audio;

    public bool vivo = true;
    Camera cam;
    Animator anim;
    public float velocidad = 25f;
    void Awake()
    {
        controles = new InputSystem_Actions();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        cam = Camera.main;
    }

    void OnEnable()
    {

        controles.Enable();
        controles.Player.Attack.performed += ctx => disparar();
        controles.Player.Jump.performed += ctx => saltar();
        controles.Player.Transformar.performed += ctx => transformar();
        StartCoroutine("EsperarUnRato");
        GameManager.instancia.jugador = this.gameObject;

    }

    void OnDisable()
    {
        controles.Disable();
    }


    void Update()
    {
        direcciones = controles.Player.Move.ReadValue<Vector2>();
        anim.SetBool("caer", !enSuelo());
    }

    void FixedUpdate()
    {
    if (!vivo) return;

    if (transform.position.y > limiteX)
    {
        direcciones.y = -1;
    }

    Vector2 dir = new Vector2(direcciones.x, 0);
    rb.AddForce(dir.normalized * velocidad, ForceMode.Force);
    controlarApuntado(direcciones.y);

    // --- LIMITAR X AL VIEWPORT ---
    Vector3 vp = cam.WorldToViewportPoint(rb.position);
    vp.x = Mathf.Clamp(vp.x, 0.05f, 0.95f);
    Vector3 world = cam.ViewportToWorldPoint(vp);

    rb.MovePosition(new Vector3(world.x, rb.position.y, rb.position.z));
    }
    void disparar()
    {
        if (GameManager.instancia.balas < 3)
        {
            Instantiate(balaPrefab, puntoDisparo.transform.position + puntoDisparo.transform.forward * 2, puntoDisparo.transform.rotation);
            GameManager.instancia.balas += 1;
            audio.Play();
        }

    }
    void saltar()
    {
        if (enSuelo())
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }

    }

    bool enSuelo()
    {
        return Physics.Raycast(transform.position, Vector3.down, 2f);
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


    IEnumerator EsperarUnRato()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.instancia.Velocidad(-5f);
        GameManager.instancia.CambiarObjetivo(transform);
    }
    IEnumerator EsperarTransformacion()
    {
        yield return new WaitForSeconds(1f);
        avion.SetActive(true);
        avion.transform.position = transform.position;
        gameObject.SetActive(false);
        GameManager.instancia.GetCtrlCombustiible().inicarConsumo();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            GestionVida.instancia.recibir_danio(1);
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("agua"))
        {
            Destroy(gameObject);
            GestionVida.instancia.perder();
        }
    }


}