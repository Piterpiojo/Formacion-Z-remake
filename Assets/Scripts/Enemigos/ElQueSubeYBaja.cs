using UnityEngine;

public class ElQueSubeYBaja : MonoBehaviour
{


    public float amplitud = 1f;
    public float velocidad = 2f;

    private float yInicial;

    void Start()
    {
        yInicial = transform.position.y;
        Destroy(gameObject, 8f);

    }

    void Update()
    {
        float nuevaY = yInicial + Mathf.Sin(Time.time * velocidad) * amplitud;
        transform.position = new Vector3(transform.position.x, nuevaY, transform.position.z);
        transform.position += Vector3.left * Time.deltaTime * 4f;
    }


}
