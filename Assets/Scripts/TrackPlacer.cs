using UnityEngine;

public class TrackPlacer : MonoBehaviour
{
    const int NULL_SECTOR = -1;

    // Segments are 1 unit wide, so current segment is just floor of the x pos
    int currentSegment = NULL_SECTOR;
    int nextSegment = NULL_SECTOR;

    public Transform character;
    public GameObject currentSegmentObject;

    public GameObject[] tracks;
    int trackI;

    private void Awake()
    {
        if (tracks.Length == 0)
            Debug.LogError("TrackPlacer tracks is empty. Add prefabs.");

        if (currentSegmentObject == null)
            Debug.LogError("Have not set currentSegmentObject!");
    }

    void Update()
    {
        int characterSegment = Mathf.FloorToInt(character.position.x);

        if (characterSegment > currentSegment)
        {
            AdvanceSector(characterSegment);

            currentSegment = characterSegment;
        }
    }

    void AdvanceSector(int sectorWeEntering)
    {
        currentSegment = sectorWeEntering;
        nextSegment = currentSegment + 1;

        SpawnSector(nextSegment + 1);
    }

    void SpawnSector(int segment)
    {
        // So this function should be reworked to spawn the next piece when the Builder Player selects the piece.

        EndingAnchor endAnchor = currentSegmentObject.GetComponentInChildren<EndingAnchor>();
        Spawn(tracks[trackI], endAnchor, segment);

        if (++trackI >= tracks.Length)
            trackI = 0;
    }

    void Spawn(GameObject prefab, EndingAnchor existingSegmentAnchor, int segmentIndex)
    {
        GameObject newObject = Object.Instantiate(prefab); // A clever person would make this InstantiateAsync :eyes:

        newObject.transform.position = existingSegmentAnchor.transform.position;

        currentSegmentObject = newObject;
        currentSegment = segmentIndex;
        nextSegment = currentSegment + 1;

    }
}
