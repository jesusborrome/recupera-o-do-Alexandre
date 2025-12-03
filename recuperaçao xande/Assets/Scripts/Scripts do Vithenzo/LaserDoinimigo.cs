using UnityEngine;

public class LaserDoinimigo : MonoBehaviour
{
    public float velocidadeDolaser;

    public int DanoparaDar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimentarlaserDOinimigo();
    }

    public void movimentarlaserDOinimigo()
    {
        transform.Translate(Vector3.up * velocidadeDolaser * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.gameObject.CompareTag("Player"))
        {
            colisao.gameObject.GetComponent<VidaDoPlayer>().DanoAoPlayer(DanoparaDar);

            Destroy(this.gameObject);
        }
    }
}
