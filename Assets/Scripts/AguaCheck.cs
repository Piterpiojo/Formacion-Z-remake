using UnityEngine;
using UnityEngine.AI;

public class AguaCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha entrado en el agua.");

        }
    }

}
