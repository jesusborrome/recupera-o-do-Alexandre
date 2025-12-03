using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public GameObject LaserDoInimigo;

    public Transform LocalDoDisparo;
    public Transform SegundoLocalDeDisparo;

    public GameObject ItemParaDropar;

    public float velocidadeDoInimigo;

    public float tempoMaximoEntreOsLasers;
    private float tempoAtualDosLasers;

    public bool InimigoAtirador;
    public bool InimigosDeDisparoDuplo;

    public int VidaMaximaDoInimigo;
    public int VidaAtualDoInimigo;

    public int SaberParaDar;

    public int chanceParaDropar;

    void Start()
    {
        // Garante que TODOS os inimigos estejam virados para baixo
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        tempoAtualDosLasers = tempoMaximoEntreOsLasers;
    }

    void Update()
    {
        MovimentarInimigo();

        if (InimigoAtirador)
            AtirarLaser();
    }

    public void MovimentarInimigo()
    {
        // Move o inimigo para baixo SEM depender da rotação dele
        transform.Translate(Vector3.down * velocidadeDoInimigo * Time.deltaTime, Space.World);
    }

    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;

        if (tempoAtualDosLasers <= 0)
        {
            // Tiro apontando para baixo (0° funciona para a maioria dos sprites)
            Quaternion rotacaoDoTiro = Quaternion.identity;

            Instantiate(LaserDoInimigo, LocalDoDisparo.position, rotacaoDoTiro);

            if (InimigosDeDisparoDuplo && SegundoLocalDeDisparo != null)
                Instantiate(LaserDoInimigo, SegundoLocalDeDisparo.position, rotacaoDoTiro);

            tempoAtualDosLasers = tempoMaximoEntreOsLasers;
        }
    }

    public void MachucarInimigo(int danoParaReceber)
    {
        VidaAtualDoInimigo -= danoParaReceber;

        if (VidaAtualDoInimigo <= 0)
        {
            GameManeger.instance.AumentarSaber(SaberParaDar);

            if (Random.Range(0, 100) <= chanceParaDropar)
                Instantiate(ItemParaDropar, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
