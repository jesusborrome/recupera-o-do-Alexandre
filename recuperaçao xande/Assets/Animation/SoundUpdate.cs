using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [Header("Som ao coletar")]
    public AudioClip collectSound;     // Som de coleta (adicione no Inspector)
    [Range(0f, 1f)]
    public float volume = 1f;          // Volume do som

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Confere se quem encostou é o Player (a nave)
        if (other.CompareTag("Player"))
        {
            // Toca o som no ponto onde o item foi pego
            AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);

            // Aqui você pode adicionar o efeito do item, se quiser
            // Exemplo: aumentar pontos, vida, etc.
            // other.GetComponent<PlayerController>().AddScore(100);

            // Destroi o item após ser coletado
            Destroy(gameObject);
        }
    }
}
