using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public GameObject LaserDoInimigo;

    public Transform LocalDoDisparo;

    public Transform SegundoLocalDeDisparo;

    public GameObject ItemParaDropar;

    public float velocidadeDoInimigo;

    public float tempoMaximoEntreOsLasers;

    public float tempoAtualDosLasers;

    public bool InimigoAtirador;

    public bool InimigosDeDisparoDuplo;

    public int VidaMaximaDoInimigo;

    public int VidaAtualDoInimigo;

    public int SaberParaDar;

    public int chanceParaDropar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();

        if(InimigoAtirador == true )
        {
            AtirarLaser();
        }
        
    }

    public void MovimentarInimigo()
    {
        transform.Translate(Vector3.down * velocidadeDoInimigo * Time.deltaTime);
    }

    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;

        if (tempoAtualDosLasers <= 0)
        {
            Instantiate(LaserDoInimigo, LocalDoDisparo.position, Quaternion.Euler(0f, 0f, 90f));
            tempoAtualDosLasers = tempoMaximoEntreOsLasers;
        }
    }

    public void MachucarInimigo(int danoParaReceber)
    {
        VidaAtualDoInimigo -= danoParaReceber;

        if(VidaAtualDoInimigo <= 0)
        {
            GameManeger.instance.AumentarSaber(SaberParaDar);

            int numeroAleatorio = Random.Range(0, 100);
            
            if(numeroAleatorio <= chanceParaDropar)
            {
                Instantiate(ItemParaDropar, transform.position, Quaternion.Euler(0f, 0f, 0f));
            }
           
            
            Destroy(this.gameObject);
        }
    }



}
