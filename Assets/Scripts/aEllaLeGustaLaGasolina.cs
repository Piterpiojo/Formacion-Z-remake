    using UnityEngine;

    public class aEllaLeGustaLaGasolina : MonoBehaviour
    {
            Rigidbody rb;


            void Start(){
                rb = GetComponent<Rigidbody>();
            }

                void FixedUpdate(){
        rb.linearVelocity = new Vector3(-330f,0,0) * Time.deltaTime;
    }
            void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<CtrlCombustiible>().Recargar(10);
                Destroy(gameObject);
                Debug.Log("entro un colision");
            }
        }

            void OnTriggerEnter(Collider other){
            if(other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<CtrlCombustiible>().Recargar(10); 
                Destroy(gameObject);
      
            }
        }
    }
