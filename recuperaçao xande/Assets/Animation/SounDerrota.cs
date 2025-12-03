using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;   // painel da tela de derrota
    public AudioSource gameOverMusic;  // som da derrota

    private bool isGameOver = false;

    public void GameOver()
    {
        if (isGameOver) return; // evita chamar várias vezes
        isGameOver = true;

        // Mostra o painel
        gameOverPanel.SetActive(true);

        // Toca a música
        if (gameOverMusic != null)
        {
            gameOverMusic.Play();
        }

        // Pausa o jogo (opcional)
        Time.timeScale = 0f;
    }
}

