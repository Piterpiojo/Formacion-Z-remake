using UnityEngine;

public class ElFondoScroll : MonoBehaviour
{
    Terrain terreno;
    public float velocidad = -1f;

    void Start()
    {
        terreno = GetComponent<Terrain>();
    }

    void Update()
    {
        transform.position +=new Vector3(velocidad,0)* Time.deltaTime;
    }
}
