using UnityEngine;
using Unity.Cinemachine;

public class PlayerController : MonoBehaviour 
{
    [SerializeField, Header("Set > 0 to start the game, 0 to stop the game")] float speed = 0.0f;
    [SerializeField] float jumpForce = 5.0f, gravity = 12.0f, verticalVelocity, speedIncreaseLastTick, speedIncreaseTime = 2.5f, speedIncreaseAmount = 0.1f;
    [SerializeField] int lane = 0, minLane = -1, maxLane = 1;
    [SerializeField] CharacterController characterController;
    [SerializeField] Animator animator;
    [SerializeField] Transform groundCheck;
    [SerializeField] CinemachineImpulseSource impulseSource;
    [SerializeField] NewTrackPlacer newTrackPlacer;

    GameObject popUp;

    public float Speed { get => speed; set => speed = value; }//Set > 0 to start the game, 0 to stop the game

    void Start()
    {
        popUp = GameObject.FindWithTag("PopUp");
        popUp.SetActive(false);
    }

    void Update()
    {
        //if ((Time.time - speedIncreaseLastTick) > speedIncreaseTime) 
        //{
        //    speedIncreaseLastTick = Time.time;
        //    Speed += speedIncreaseAmount;
        //    //GameManager.Instance.Modifier = Speed - originalSpeed;
        //}

        animator.SetBool("Run",Speed > 0);
        animator.SetBool("IsGrounded", IsGrounded());

        if (Speed == 0) { return; }

        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                animator.SetBool("IsSliding", true);
                characterController.height /= 2;
                characterController.center = new Vector3(characterController.center.x, characterController.center.y / 2, characterController.center.z);
                Invoke("StopSliding",1f);
            }

            if(Input.GetKeyDown(KeyCode.W) )
            {
                if( ! animator.GetBool("IsSliding"))
                {
                    verticalVelocity = jumpForce;
                }
            }
        }
        else
        {
            verticalVelocity -= (gravity * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.S))
            {
                verticalVelocity = -jumpForce;
            }
        }

        lane += Input.GetKeyDown(KeyCode.A) ? 1 : Input.GetKeyDown(KeyCode.D) ? -1 : 0;
        lane = Mathf.Clamp(lane, minLane, maxLane);
        Vector3 targetPosition = (transform.position.x * Vector3.right) + (Vector3.forward * lane);
        Vector3 moveVector = new Vector3(Speed, verticalVelocity, (targetPosition - transform.position).normalized.z * Speed);
        characterController.Move(moveVector * Time.deltaTime);

        Vector3 dir = characterController.velocity;
        if(dir != Vector3.zero)
        {
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, 0.05f);
        }       
    }

    void Die()
    {
        animator.SetTrigger("Die");
        Speed = 0;
        impulseSource.GenerateImpulse();
        popUp.SetActive(true);
        //TODO:
        //AudioManager.Instance.PlaySound_Death(); //Gavin, you can add this line if you want to play a sound when the target dies.     
    }

    bool IsGrounded()
    {
        Ray groundRay = new Ray(groundCheck.position, Vector3.down);
        return Physics.Raycast(groundRay, 0.2f);
    }

    void StopSliding()
    {
        characterController.height *= 2;
        characterController.center = new Vector3(characterController.center.x, characterController.center.y * 2, characterController.center.z);
        animator.SetBool("IsSliding", false);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Death"))
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stop"))
        {
            Speed = 0;
            newTrackPlacer.SpawnRandomTracks(true);
        }
    }
}
