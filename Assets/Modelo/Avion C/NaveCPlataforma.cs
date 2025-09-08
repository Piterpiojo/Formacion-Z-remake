using UnityEngine;

public class NaveCPlataforma : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;

    [SerializeField] private float velocidadMovimiento = 5f;
    [SerializeField] private float fuerzaSalto = 8f;
    [SerializeField] private float gravedad = 20f;

    private Vector3 mover;
    private float velocidadY;

    [Header("Transformación")]
    public GameObject AVIONMODELOC;   
    public GameObject AVIONMODELOtex; 
    private GameObject modeloActual;  

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        if (AVIONMODELOC != null)
            modeloActual = AVIONMODELOC;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moverPlano = new Vector3(moveX * velocidadMovimiento, 0, 0);

        if (controller.isGrounded)
        {
            anim.SetFloat("Saltar", 0);
            velocidadY = -1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocidadY = fuerzaSalto;
                anim.SetFloat("Saltar", 1);
            }
        }
        else
        {
            velocidadY -= gravedad * Time.deltaTime;
            anim.SetFloat("Saltar", 1);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)))
        {
            anim.SetBool("MirarArriba", true);
        }
        else
        {
            anim.SetBool("MirarArriba", false);
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)))
        {
            anim.SetBool("MirarAbajo", true);
        }
        else
        {
            anim.SetBool("MirarAbajo", false);
        }

        mover = moverPlano;
        mover.y = velocidadY;

        controller.Move(mover * Time.deltaTime);

        anim.SetFloat("PosX", moveX);

        if (Input.GetKeyDown(KeyCode.Q))
            anim.SetFloat("Transformar", 1f);
    }
    public void CambiarModelo()
    {
        if (modeloActual != null)
            Destroy(modeloActual);

        if (AVIONMODELOtex != null)
        {
            GameObject nuevo = Instantiate(AVIONMODELOtex, transform.position, transform.rotation, transform);
            modeloActual = nuevo;
        }

        anim.SetFloat("Transformar", 0f);
    }
}
