using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class TheBestCharacterController : MonoBehaviour
{
    public float speed = 1f;
    public float jumpSpeed = 1f;
    [SerializeField] Transform groundCheck;
    [SerializeField] PopUp popUp;
    public InputAction jumpAction;
    public ParticleSystem jumpParticles;
    public int maxHeight = 1;
    public UpperEnemy upperEnemy;
    Renderer playerRenderer;
    bool shouldAttackPlayer = false;
    
    Rigidbody rb;
    CinemachineImpulseSource impulseSource;
    Vector3 startPosition;

    void Awake()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        playerRenderer = GetComponentInChildren<Renderer>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
        jumpAction.Enable();
    }

    void Update()
    {
        rb.MovePosition(rb.position + (Vector3.right * speed * Time.deltaTime));

        if (jumpAction.triggered)
        {           
            if(speed > 0)
            {
                if (IsGrounded()) // Must check if we are grounded.
                {
                    rb.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
                    AudioManager.Instance.PlaySound_Jump();
                    jumpParticles.Play();
                }
            }
        }

        CheckIfFalling();
        CheckIfTooHigh();
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

    public void Run()
    {
        speed = 1;
        playerRenderer.enabled=true;
    }

    //[ContextMenu("Die")]//For testing purposes
    void Die()
    {
        speed = 0;
        impulseSource.GenerateImpulse();
        PopUpData popUpData = new PopUpData();
        popUpData.messages.Add("You died!");
        popUpData.messages.Add("GAME OVER");
        UnityEvent action = new UnityEvent();
        action.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
        popUpData.unityEvents.Add(action);
        popUp.Show(popUpData);
        //TODO:
        //AudioManager.Instance.PlaySound_Death(); //Gavin, you can add this line if you want to play a sound when the target dies.
        //Show a death animation.
        
        upperEnemy.ShouldAttackPlayer(false);
        playerRenderer.enabled=false;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            playerRenderer.enabled = false;
            upperEnemy.ShouldAttackPlayer(false);
            
            var enemyRenderer = collision.gameObject.GetComponent<Renderer>();
            enemyRenderer.enabled = false;
                
            Die();
        }
    }

    void CheckIfTooHigh()
    {
         if (rb.transform.position.y >= maxHeight )
         {
             shouldAttackPlayer = true;
             upperEnemy.ShouldAttackPlayer(shouldAttackPlayer);
         }
    }
}
