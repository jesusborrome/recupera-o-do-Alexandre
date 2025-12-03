using UnityEngine;

public class DestruicomoTempo : MonoBehaviour
{
    public float tempodeVida;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, tempodeVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
