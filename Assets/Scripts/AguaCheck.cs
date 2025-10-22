using UnityEngine;


public class AguaCheck : MonoBehaviour
{
    [SerializeField] bool jefe = false;
    [SerializeField] GameObject jefazo;

    [SerializeField] GameObject[] spawns_agua;
    [SerializeField] GameObject[] todos_spawns;

    void Start()
    {
        if (jefe)
        {
            jefazo = GameObject.FindGameObjectWithTag("jefe");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !jefe)
        {
            deshabilitar();

        }
        if (other.CompareTag("Player") && jefe)
        {
            if (jefazo != null)
            {
                GameManager.instancia.jugador.GetComponent<CtrlCombustiible>().deshabilitarConsumo();
                deshabilitar_todos();
                jefazo.SetActive(true);
                
            }
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
