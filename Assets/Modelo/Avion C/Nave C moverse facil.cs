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

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveZ = Input.GetAxis("Vertical");
        float rotY = Input.GetAxis("Horizontal");

        moveZ = -moveZ;

        Vector3 moverPlano = transform.forward * moveZ * velocidadMovimiento;
        transform.Rotate(Vector3.up * rotY * velocidadRotacion * Time.deltaTime);

       
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
        
        anim.SetFloat("PosZ", moveZ);
        anim.SetFloat("PosX", rotY);

        if (Input.GetKey(KeyCode.F)) 
        {
            anim.SetFloat("Disparar",1f);
        }
        else
        {
            anim.SetFloat("Disparar",0f);
        }
    }

}
