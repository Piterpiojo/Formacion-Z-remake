using UnityEngine;

public class NaveCmoversefacil : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;

    [SerializeField] private float velocidadMovimiento = 5f;
    [SerializeField] private float velocidadRotacion = 180f;
    [SerializeField] private float fuerzaSalto = 8f;
    [SerializeField] private float gravedad = 20f;

    private Vector3 mover;
    private float velocidadY;

    [Header("Transformación")]
    public GameObject AVIONMODELOC;   // Modelo inicial (hijo del objeto principal)
    public GameObject AVIONMODELOtex; // Prefab del modelo al que se transformará
    private GameObject modeloActual;  // El que está activo en este momento

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        // Si el modelo inicial está en jerarquía como hijo del Player, lo guardamos
        if (AVIONMODELOC != null)
        {
            modeloActual = AVIONMODELOC;
        }
        else
        {
            Debug.LogWarning("No asignaste AVIONMODELOC en el inspector.");
        }
    }

    void Update()
    {
        float moveZ = Input.GetAxis("Vertical");
        float rotY = Input.GetAxis("Horizontal");

        // Invertir Z si lo necesitás
        moveZ = -moveZ;

        Vector3 moverPlano = transform.forward * moveZ * velocidadMovimiento;
        transform.Rotate(Vector3.up * rotY * velocidadRotacion * Time.deltaTime);

        // Saltar
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

        mover = moverPlano;
        mover.y = velocidadY;
        controller.Move(mover * Time.deltaTime);

        // Animaciones de movimiento
        anim.SetFloat("PosZ", moveZ);
        anim.SetFloat("PosX", rotY);

        // Disparar
        if (Input.GetKey(KeyCode.F))
            anim.SetFloat("Disparar", 1f);
        else
            anim.SetFloat("Disparar", 0f);

        // Transformar (al apretar Q empieza la animación Transformar)
        if (Input.GetKeyDown(KeyCode.Q))
            anim.SetFloat("Transformar", 1f);
    }

    /// <summary>
    /// Llamado desde el Animation Event al final de la animación Transformar
    /// </summary>
    public void CambiarModelo()
    {
        if (AVIONMODELOC != null)
        {
            Destroy(AVIONMODELOC); // 🔥 Destruye el modelo que estaba activo en escena
        }

        if (AVIONMODELOtex != null)
        {
            // Instancia el nuevo como hijo del objeto principal (Player)
            GameObject nuevo = Instantiate(AVIONMODELOtex, transform.position, transform.rotation, transform);

            modeloActual = nuevo; // 🔄 Ahora este será el nuevo modelo actual
        }

        // Reseteamos el parámetro
        anim.SetFloat("Transformar", 0f);
    }
}
