using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrocaDeCenaControl()
    {
        SceneManager.LoadScene("Control");
        Time.timeScale = 1f;
    }

    public void TrocaDeCenaStart()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1f;
    }
    public void TrocaDeCenaEscola()
    {
        SceneManager.LoadScene("escola");
        Time.timeScale = 1f;
    }

    public void TrocaDeCenaRua()
    {
        SceneManager.LoadScene("Rua");
        Time.timeScale = 1f;
    }

    public void TrocaDeCenaQuarto()
    {
        SceneManager.LoadScene("Quarto");
        Time.timeScale = 1f;
    }

    public void TrocaDeCenaMesa()
    {
        SceneManager.LoadScene("Vithenzo");
        Time.timeScale = 1f;
    }

    public void TrocaDeCenaGame()
    {
        SceneManager.LoadScene("Créditos");
        Time.timeScale = 1f;
    }
    
    public void TrocaDeCenaFim()
    {
        SceneManager.LoadScene("FimQuarto");
    }

    public void TrocaDeCenaCreditos()
    {
        SceneManager.LoadScene("Créditos");
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Sair()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}
