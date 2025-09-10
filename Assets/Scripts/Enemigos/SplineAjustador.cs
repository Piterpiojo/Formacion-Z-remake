using UnityEngine;

public class SplineAjustador : MonoBehaviour
{
    Camera camera;
    float Xviewport = 1f;


    void Start()
    {
        camera = Camera.main;
    }
    void LateUpdate()
    {
        Vector3 pos = new Vector3(Xviewport, 0.5f, 12f);
        Vector3 worldPos = camera.ViewportToWorldPoint(pos);
        worldPos.z = 12f; 
        transform.position = worldPos;
    }
}
