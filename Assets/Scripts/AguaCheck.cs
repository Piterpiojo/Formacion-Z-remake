using UnityEngine;


public class AguaCheck : MonoBehaviour
{
    [SerializeField] bool jefe = false;
    [SerializeField] GameObject jefazo;

    [SerializeField] GameObject[] spawns_agua;
    [SerializeField] GameObject[] todos_spawns;

    void Start()
    {
        if (jefe && jefazo != null)
        {
            jefazo = GameObject.FindGameObjectWithTag("jefe");

        }
        jefazo.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && !jefe)
        {
            deshabilitar();
  

        }
        if (other.CompareTag("Player") && jefe)
        {
 
                GameManager.instancia.GetCtrlCombustiible().deshabilitarConsumo();
                deshabilitar_todos();
                jefazo.SetActive(true);
                
            
        }
    }


            void deshabilitar()
    {
        foreach (GameObject spawn in spawns_agua)
        {
            spawn.SetActive(false);
        }
    }

    void deshabilitar_todos()
    {
        foreach (GameObject spawn in todos_spawns)
        {
            spawn.SetActive(false);
        }
    }

}
