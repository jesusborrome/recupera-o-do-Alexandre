using UnityEngine;
using TMPro;

public class GameManeger : MonoBehaviour
{
    public int SaberAtual;

    public int pontosParaVitoria = 1000;

    public static GameManeger instance;

    [Header("UI")]
    public TMP_Text TextodeSaberAtual; 
    public GameObject telaVitoria;


    [Header("Referências Extras")]
    public GeradorDeObjetos geradorInimigos;
    public GameObject painelDialogo; 

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SaberAtual = 0;
        AtualizarTextoSaber();

        if (telaVitoria != null)
            telaVitoria.SetActive(false);

        if (painelDialogo != null)
            painelDialogo.SetActive(false);
    }

    public void AumentarSaber(int SaberParaGanhar)
    {
        SaberAtual += SaberParaGanhar;
        AtualizarTextoSaber();
        Debug.Log("Pontuação atual: " + SaberAtual);
        VerificarProgresso();
    }

    private void AtualizarTextoSaber()
    {
        if (TextodeSaberAtual != null)
            TextodeSaberAtual.text = "Saber: " + SaberAtual;
    }

    private void VerificarProgresso()
    { 
        // Tela de vitória
        if (SaberAtual >= pontosParaVitoria)
        {
            if (telaVitoria != null)
                telaVitoria.SetActive(true);
        }
    }

    // Chamado quando o diálogo terminar
    public void RetomarJogoAposDialogo()
    {
        Debug.Log("Diálogo terminou, retomando spawns...");

        if (geradorInimigos != null)
            geradorInimigos.RetomarSpawns();

        if (painelDialogo != null)
            painelDialogo.SetActive(false);
    }
}

