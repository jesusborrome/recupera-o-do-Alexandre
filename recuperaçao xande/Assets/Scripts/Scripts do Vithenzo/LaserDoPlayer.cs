
using UnityEngine;

public class LaserDoPlayer : MonoBehaviour
{
    public float velocidadeDolaser;

    public int DanoParaDar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarOlaser();
    }
    private void MovimentarOlaser()
    {
        transform.Translate(Vector3.up * velocidadeDolaser * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.CompareTag("Inimigo"))
        {
            colisao.gameObject.GetComponent<Inimigos>().MachucarInimigo(DanoParaDar);
            Destroy(this.gameObject);
        }
    }

}
