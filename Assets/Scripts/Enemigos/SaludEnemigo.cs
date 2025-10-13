using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{
    public int salud = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void recibirDanio(){
        salud -=1;
        if (salud < 1)
        Destroy(gameObject);
    }
}
