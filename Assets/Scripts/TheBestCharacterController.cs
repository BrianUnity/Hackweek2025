using UnityEngine;
using UnityEngine.InputSystem;

public class TheBestCharacterController : MonoBehaviour
{
    public float speed = 1f;
    public float jumpSpeed = 1f;
    [SerializeField] Transform groundCheck;

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
            if (IsGrounded()) // Must check if we are grounded.
            {
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
                AudioManager.Instance.PlaySound_Jump();
            }
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

    bool IsGrounded()
    {
        Ray groundRay = new Ray(groundCheck.position, Vector3.down);
        return Physics.Raycast(groundRay, 0.3f);
    }
}
