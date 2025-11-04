using UnityEngine;

public class SubirYbajar : MonoBehaviour
{

    public float amplitud = 2f;
    public float frecuencia = 2f;
    private Vector3 posicionInicial;

    [SerializeField] GameObject jugador;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float offsetX = Mathf.Sin(Time.time * frecuencia) * amplitud;
        transform.position = new Vector3(transform.position.x, transform.parent.transform.position.y + offsetX, transform.position.z);
        Vector3 targetPos = jugador.transform.position;


        Vector3 flatTarget = new Vector3(targetPos.x, targetPos.y, targetPos.z);


        Vector3 dir = (flatTarget - transform.position);
        if (dir.sqrMagnitude < 0.0001f) return; // evita NaNs

        Quaternion desiredRot = Quaternion.LookRotation(dir.normalized, Vector3.up);


        transform.rotation = desiredRot;
    }


}
