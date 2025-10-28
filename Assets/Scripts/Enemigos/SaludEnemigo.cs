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
        {
            if (gameObject.CompareTag("jefe"))
            {
                Destroy(transform.parent.gameObject);
                GestionVida.instancia.perder();

            }
            Destroy(gameObject);
        }
    }





}
