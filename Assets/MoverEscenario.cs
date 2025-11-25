using UnityEngine;

public class MoverEscenario : MonoBehaviour
{
    public float velocidad = 0.05f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * velocidad;
        rend.material.mainTextureOffset = new Vector2(offset, offset);
    }
}
