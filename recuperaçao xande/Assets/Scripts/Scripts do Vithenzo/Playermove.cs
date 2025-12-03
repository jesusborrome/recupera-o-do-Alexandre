using UnityEngine;

public class Playermove : MonoBehaviour
{
    public GameObject laserDojogador;

    public Transform LocalDoDisparo;

    public float velocidadeDaNave;

    private Vector2 TeclasApertadas;

    public Rigidbody2D body;

    public Transform LocalDoDisparoDaEsquerda;

    public Transform LocalDODisparoDaDireita;

    public float TempoMaximoDosLasersDuplos;

    public float TempoAtualDosLasersDuplos;

    public bool temLaserDuplo;

    void Start()
    {
        temLaserDuplo = false;

        TempoAtualDosLasersDuplos = TempoMaximoDosLasersDuplos;
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AtirarlazerDoPlayer();

        MovimentarJogador();

        if(temLaserDuplo == true)
        {
            TempoAtualDosLasersDuplos -= Time.deltaTime;

            if(TempoAtualDosLasersDuplos <= 0)
            {
                DesativarLaserDuplo();
            }
        }
    }

    public void MovimentarJogador()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        // Movimento apenas para os lados
        Vector2 movimento = new Vector2(horizontal, 0f);

        body.linearVelocity = movimento.normalized * velocidadeDaNave;
    }


    public void AtirarlazerDoPlayer()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (temLaserDuplo == false)
            {
                Instantiate(laserDojogador, LocalDoDisparo.position, LocalDoDisparo.rotation);
            }
            else
            {
                Instantiate(laserDojogador, LocalDoDisparoDaEsquerda.position, LocalDoDisparo.rotation);
                Instantiate(laserDojogador, LocalDODisparoDaDireita.position, LocalDoDisparo.rotation);
            }
        }
    }

   private void DesativarLaserDuplo()
    {
        temLaserDuplo = false;
        TempoAtualDosLasersDuplos = TempoMaximoDosLasersDuplos;
    }
}

