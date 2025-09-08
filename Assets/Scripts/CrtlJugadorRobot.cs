using UnityEngine;

public class CrtlJugadorRobot : MonoBehaviour
{
    InputSystem_Actions controles;
    public Vector2 direcciones;
    public GameObject balaPrefab;
    Rigidbody rb;

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
        controles.Enable();
        controles.Player.Attack.performed += ctx => disparar();
        controles.Player.Jump.performed += ctx => saltar();
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
        direcciones.y = 0;
        rb.AddForce(direcciones.normalized * velocidad, ForceMode.Impulse);
    }
    void disparar()
    {
        Instantiate(balaPrefab, puntoDisparo.transform.position + puntoDisparo.transform.forward * 2, puntoDisparo.transform.rotation);
    }
    void saltar()
    {
        if (transform.position.y < limitey)
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
}