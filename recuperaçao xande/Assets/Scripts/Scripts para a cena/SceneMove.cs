using UnityEngine;

public class SceneMove : MonoBehaviour
{
    public float speed = 2f; // velocidade do scroll
    public float resetPositionY = 1920f; // posição Y para resetar
    public float startPositionY = 10f; // nova posição Y ao resetar

    void Update()
    {
        // Move o fundo para baixo
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Quando sair da tela, reposiciona no topo
        if (transform.position.y <= resetPositionY)
        {
            Vector2 newPos = new Vector2(transform.position.x, startPositionY);
            transform.position = newPos;
        }
    }
}
