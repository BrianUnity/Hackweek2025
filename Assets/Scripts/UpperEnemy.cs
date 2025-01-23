using UnityEngine;

public class UpperEnemy : MonoBehaviour
{
    Rigidbody rb;
    Renderer enemyRenderer;

    public float speed = 1f;
    private bool shouldAttackPlayer = false;
    public GameObject player;
    private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldAttackPlayer)
        {
            // enemyRenderer.enabled = true;

            target = player.transform;
            // rb.MovePosition(rb.position + (Vector3.left * speed * Time.deltaTime));
            
            // Move our position a step closer to the target.
            var step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                // Swap the position of the cylinder.
                // target.position *= -1.0f;
                // shouldAttackPlayer = false;
            }
        }
        else
        {
            // enemyRenderer.enabled = false;
        }
    }

    public void ShouldAttackPlayer(bool shouldAttack)
    {
        shouldAttackPlayer = shouldAttack;
    }
}
