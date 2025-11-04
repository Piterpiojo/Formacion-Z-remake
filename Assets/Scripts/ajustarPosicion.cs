using UnityEngine;

public class ajustarPosicion : MonoBehaviour
{
    Camera cam;
    [SerializeField] float xViewport = 0.5f;
    [SerializeField] float yViewport = 0.5f;
    float distanciaZ;

    void Start()
    {
        cam = Camera.main;

        // Calculamos a qué distancia del plano de la cámara está el objeto actualmente
        Vector3 camToObj = transform.position - cam.transform.position;
        distanciaZ = Vector3.Dot(camToObj, cam.transform.forward);
    }

    void LateUpdate()
    {
        // Convertimos las coordenadas de viewport a mundo manteniendo la distancia original
        Vector3 worldPos = cam.ViewportToWorldPoint(new Vector3(xViewport, yViewport, distanciaZ));
        transform.position = worldPos;
    }
}
