using UnityEngine;

public class TheBestCharacterController : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        this.transform.position += (Vector3.right * speed * Time.deltaTime);
    }
}
