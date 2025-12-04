using UnityEngine;

public class GeradorDeObjetos : MonoBehaviour
{
    public Transform[] pontoDeSpawn;
    public GameObject[] objetosParaSpawnar;
    public float tempoMaximoEntreOsSpwans;
    public float TempoAtualDosSpwans;

    public bool PodeSpawnar { get; private set; } = true;

    void Start()
    {
        TempoAtualDosSpwans = tempoMaximoEntreOsSpwans;
    }

    void Update()
    {
        if (!PodeSpawnar) return;

        TempoAtualDosSpwans -= Time.deltaTime;

        if (TempoAtualDosSpwans <= 0)
        {
            SpawnarObjeto();
        }
    }
    private void SpawnarObjeto()
    {
        int ObjetoAleatorio = Random.Range(0, objetosParaSpawnar.Length);
        int pontoAleatorio = Random.Range(0, pontoDeSpawn.Length);

        Quaternion apontarParaBaixo = Quaternion.Euler(0f, 0f, 90f);

        Instantiate(
            objetosParaSpawnar[ObjetoAleatorio],
            pontoDeSpawn[pontoAleatorio].position,
            apontarParaBaixo
        );

        TempoAtualDosSpwans = tempoMaximoEntreOsSpwans;
    }

    public void PausarSpawns()
    {
        PodeSpawnar = false;
    }

    public void RetomarSpawns()
    {
        PodeSpawnar = true;
        TempoAtualDosSpwans = tempoMaximoEntreOsSpwans;
    }
}