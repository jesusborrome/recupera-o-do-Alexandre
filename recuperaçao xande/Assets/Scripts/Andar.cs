using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Andasr : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float rotationSpeed = 10f; // opcional: faz o player olhar para a dire��o do movimento
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // evita tombar
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float v = Input.GetAxisRaw("Vertical");   // W/S or Up/Down

        Vector3 move = new Vector3(h, 0f, v).normalized * moveSpeed;
        Vector3 newVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
        rb.linearVelocity = newVelocity;

        // opcional: rotacionar para dire��o do movimento
        Vector3 flatMove = new Vector3(move.x, 0, move.z);
        if (flatMove.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(flatMove);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
