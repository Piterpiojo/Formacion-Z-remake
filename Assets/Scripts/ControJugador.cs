using UnityEngine;

public class ControJugador : MonoBehaviour
{
    InputSystem_Actions controles;
    public Vector2 direcciones;
    public GameObject balaPrefab;
    Rigidbody rb;

    public GameObject robot
    ;


    float limiteX = 60f;
    float limitey = 0.2f;
    public GameObject puntoDisparo;

    public bool vivo = true;

    Animator anim;
    public float velocidad = 25f;

    AudioSource audio;
    void Awake()
    {
        controles = new InputSystem_Actions();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

    }

    void OnEnable()
    {
        GameManager.instancia.Velocidad(-15f);
        GameManager.instancia.CambiarObjetivo(transform);
        controles.Enable();
        controles.Player.Attack.performed += ctx => disparar();
        controles.Player.Transformar.performed += ctx => transformar();
        GameManager.instancia.jugador = this.gameObject;
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

        rb.AddForce(direcciones.normalized * velocidad, ForceMode.Acceleration);
        anim.SetFloat("Y", direcciones.y);
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
        void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            Destroy(gameObject);
            GestionVida.instancia.perder();
        }
    }


    public void FaltaCombustible()
    {
        rb.useGravity = true;
    }



    void transformar()
    {
        GameManager.instancia.volando = false;
        GameManager.instancia.GetCtrlCombustiible().deshabilitarConsumo();
        robot.SetActive(true);
        robot.transform.position = transform.position;
        gameObject.SetActive(false);
       
    }
    
        void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            GestionVida.instancia.recibir_danio(1);
            Destroy(other.gameObject);
        }
    }
}
