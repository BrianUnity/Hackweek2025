using UnityEngine;

public class TrackPlacer : MonoBehaviour
{
    public GameObject initialSegment;
    [SerializeField] Transform theBestCharacterController;
    [SerializeField] float distanceToPlaceTrack = 2f;
    EndingAnchor lastSegmentEndAnchor;

    private void Awake()
    {
        if (initialSegment == null)
            Debug.LogError("Have not set initialSegment!");

        lastSegmentEndAnchor = initialSegment.GetComponentInChildren<EndingAnchor>(); // We have the initial segment at 0.
    }

    public void SpawnTrackPiece(GameObject trackPrefab)
    {
        if(Vector2.Distance(theBestCharacterController.position, lastSegmentEndAnchor.transform.position) > distanceToPlaceTrack)
        {
            Debug.Log("Too far away to place track!");
            return;
        }

        Spawn(trackPrefab, lastSegmentEndAnchor);
    }

    void Spawn(GameObject prefab, EndingAnchor existingSegmentAnchor)
    {
        GameObject newSegment = Object.Instantiate(prefab); // A clever person would make this InstantiateAsync :eyes:

        newSegment.transform.position = existingSegmentAnchor.transform.position;
        lastSegmentEndAnchor = newSegment.GetComponentInChildren<EndingAnchor>();
        
        AudioManager.Instance.PlaySound_PlatformPlace();
    }
}
