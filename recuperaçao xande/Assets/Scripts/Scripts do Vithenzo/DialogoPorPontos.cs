using UnityEngine;
using System.Collections;

public class DialogoPorPontos : MonoBehaviour
{
    [Header("Referências")]
    public DialogoSistema dialogoSistema;
    public DialogueData[] dialogosPorPontos;
    public int[] pontosParaAtivar;

    private int proximoDialogoIndex = 0;
    private bool dialogoAtivo = false;
    private Coroutine fluxoCoroutine = null;

    void Update()
    {
        if (GameManeger.instance == null || dialogoSistema == null)
            return;

        int pontos = GameManeger.instance.SaberAtual;

        // debug para monitorar
        Debug.Log($"[DialogoPorPontos] Pontos: {pontos} | proximoDialogoIndex: {proximoDialogoIndex} | dialogoAtivo: {dialogoAtivo}");

        if (!dialogoAtivo && proximoDialogoIndex < pontosParaAtivar.Length)
        {
            int alvo = pontosParaAtivar[proximoDialogoIndex];
            if (pontos >= alvo)
            {
                Debug.Log($"[DialogoPorPontos] Requisitado início do diálogo {proximoDialogoIndex} (pontos >= {alvo})");
                if (fluxoCoroutine == null)
                    fluxoCoroutine = StartCoroutine(FluxoDialogo(proximoDialogoIndex));
                else
                    Debug.LogWarning("[DialogoPorPontos] Tentativa de iniciar diálogo enquanto outro fluxoCoroutine está ativo.");
            }
        }
    }

    IEnumerator FluxoDialogo(int index)
    {
        dialogoAtivo = true;

        // pausa spawns imediatamente
        if (GameManeger.instance != null && GameManeger.instance.geradorInimigos != null)
        {
            GameManeger.instance.geradorInimigos.PausarSpawns();
            Debug.Log("[DialogoPorPontos] Spawns pausados pelo DialogoPorPontos.");
        }

        // garante que o painel está ativo antes de setar dados
        if (!dialogoSistema.gameObject.activeSelf)
            dialogoSistema.gameObject.SetActive(true);

        // assegura que o DialogueData existe e tem falas
        if (dialogosPorPontos == null || index < 0 || index >= dialogosPorPontos.Length || dialogosPorPontos[index] == null)
        {
            Debug.LogError($"[DialogoPorPontos] DialogueData inválido no índice {index}.");
            // retoma spawns e limpa estado
            if (GameManeger.instance != null && GameManeger.instance.geradorInimigos != null)
                GameManeger.instance.geradorInimigos.RetomarSpawns();
            dialogoAtivo = false;
            fluxoCoroutine = null;
            yield break;
        }

        // troca o diálogo explicitamente antes de iniciar
        dialogoSistema.dialogueData = dialogosPorPontos[index];
        dialogoSistema.IniciarDialogo();
        Debug.Log($"[DialogoPorPontos] Diálogo {index} iniciado.");

        // espera até que o painel seja fechado (DialogoSistema chama GameManager.RetomarJogoAposDialogo e desativa o painel)
        yield return new WaitUntil(() => dialogoSistema == null || !dialogoSistema.gameObject.activeSelf);

        // garante que os spawns foram retomados (ou retoma aqui)
        if (GameManeger.instance != null && GameManeger.instance.geradorInimigos != null)
        {
            GameManeger.instance.geradorInimigos.RetomarSpawns();
            Debug.Log("[DialogoPorPontos] Spawns retomados após diálogo.");
        }

        // só avança o índice depois que terminou
        proximoDialogoIndex++;
        dialogoAtivo = false;
        fluxoCoroutine = null;

        Debug.Log($"[DialogoPorPontos] Diálogo {index} encerrado. proximoDialogoIndex agora {proximoDialogoIndex}.");
    }
}