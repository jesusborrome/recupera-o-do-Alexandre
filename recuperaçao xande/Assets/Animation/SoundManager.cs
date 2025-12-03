using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioClip soundClip;  // o som que será tocado
    private AudioSource audioSource;

    void Start()
    {
        // Cria (ou obtém) um componente AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        // Detecta clique do botão esquerdo do mouse
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(soundClip);
        }
    }
}

