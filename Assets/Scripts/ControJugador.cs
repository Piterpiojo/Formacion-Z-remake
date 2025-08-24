using UnityEngine;

public class ControJugador : MonoBehaviour
{
    InputSystem_Actions controles;
    public Vector2 direcciones;
    Rigidbody rb;

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
        rb.AddForce(direcciones.normalized * velocidad, ForceMode.Acceleration);
        anim.SetFloat("Y", direcciones.y);
    }
}
