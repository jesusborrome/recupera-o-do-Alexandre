using UnityEngine;

public class CenarioInifinito : MonoBehaviour
{
    public float VelocidadeDoCenario;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarCenario();
    }

    public void MovimentarCenario()
    {
        Vector2 DeslocamentoDocenario = new Vector2(Time.time * VelocidadeDoCenario, 0f);
        GetComponent<Renderer>().material.mainTextureOffset = DeslocamentoDocenario;
    }


}
