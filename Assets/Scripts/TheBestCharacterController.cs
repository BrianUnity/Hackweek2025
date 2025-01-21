using UnityEngine;
using UnityEngine.InputSystem;

public class TheBestCharacterController : MonoBehaviour
{
    public float speed = 1f;
    public float jumpSpeed = 1f;

    public InputAction jumpAction;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        jumpAction.Enable();
    }

    void Update()
    {
        rb.MovePosition(rb.position + (Vector3.right * speed * Time.deltaTime));

        if (jumpAction.triggered)
        {
            // Must check if we are grounded.
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
            AudioManager.Instance.PlaySound_Jump();
        }

        CheckIfFalling();
    }

    void CheckIfFalling()
    {
        if (rb.transform.position.y < 0)
        {
            AudioManager.Instance.PlaySound_Fall();
        }
    }
}
