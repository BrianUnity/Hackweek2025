using UnityEngine;
using UnityEngine.Serialization;

public class SpawnObjectRepeat : MonoBehaviour
{
    public GameObject firstObject;
    EndingAnchor lastSegmentEndAnchor;
    public GameObject objectToPlace;

    private void Awake()
    {
        if (firstObject == null)
            Debug.LogError("Have not set initialTrack!");

        lastSegmentEndAnchor = firstObject.GetComponentInChildren<EndingAnchor>(); // We have the initial segment at 0.
    }
    
    void Start()
    {
        InvokeRepeating("SpawnObject", 5.0f, 5.0f);
    }

    public void SpawnObject()
    {
        Spawn(objectToPlace, lastSegmentEndAnchor);
    }

    void Spawn(GameObject prefab, EndingAnchor existingSegmentAnchor)
    {
        GameObject newSegment = Object.Instantiate(prefab); // A clever person would make this InstantiateAsync :eyes:

        newSegment.transform.position = existingSegmentAnchor.transform.position;
        lastSegmentEndAnchor = newSegment.GetComponentInChildren<EndingAnchor>();
    }
}