using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryPanel;    // painel da tela de vitória
    public AudioSource victoryMusic;   // som da vitória

    private bool hasWon = false;

    public void WinGame()
    {
        if (hasWon) return; // impede tocar várias vezes
        hasWon = true;

        // mostra a tela
        victoryPanel.SetActive(true);

        // toca a música de vitória
        if (victoryMusic != null)
        {
            victoryMusic.Play();
        }

        // pausa o jogo (opcional)
        Time.timeScale = 0f;
    }
}

