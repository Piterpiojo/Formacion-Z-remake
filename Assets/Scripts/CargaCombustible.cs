using UnityEngine;

public class CargaCombustible : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<CtrlCombustiible>().Recargar(10);
    }

}
