using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // prefab do tiro
    public Transform firePoint;     // posição de onde o tiro sai
    public AudioClip shootSound;    // som do tiro
    private AudioSource audioSource;

    void Start()
    {
        // Pega o componente AudioSource da nave
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Detecta clique do botão esquerdo do mouse
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Cria o tiro
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Toca o som do tiro
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
}
