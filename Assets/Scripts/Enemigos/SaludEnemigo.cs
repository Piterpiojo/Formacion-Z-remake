using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{
    public int salud = 5;
    public  bool final;

    void Start()
    {

    }

    public void recibirDanio()
    {
        Debug.Log("Enemigo recibe daño");
        salud -= 1;
        if (salud < 1 )
        {
            if (gameObject.CompareTag("jefe") && final)
            {
                Destroy(transform.parent.gameObject);
                GameManager.instancia.CambiarNivel();

            }
            Destroy(gameObject);
        }
    }





}
