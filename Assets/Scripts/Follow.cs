using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform target;

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
    }
}
