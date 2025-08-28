using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject jugador;
    public static GameManager instancia ;
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        instancia = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
