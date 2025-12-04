using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;  // velocidade do personagem

    private Rigidbody rb;
    private Vector3 movementInput = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // evita girar com a física
    }

    void Update()
    {
        // entrada do jogador: horizontal e vertical
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");   // CORRIGIDO

        // cria o vetor de movimento usando Vector3
        movementInput = transform.right * x + transform.forward * z;
        movementInput = movementInput.normalized;
    }

    void FixedUpdate()
    {
        // aplica movimento com Rigidbody
        Vector3 velocity = movementInput * speed;
        Vector3 newPos = rb.position + velocity * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }
}
