using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{
    public int salud = 5;

    void Start()
    {

    }

    public void recibirDanio()
    {
        Debug.Log("Enemigo recibe daño");
        salud -= 1;
        if (salud < 1)
            Destroy(gameObject);
    }
}
