using UnityEngine;
using UnityEngine.InputSystem;

public class TrackSelector : MonoBehaviour
{
    // These need to be replaced with a better track selector. This is just getting us started.
    public GameObject track1;
    public GameObject track2;
    public GameObject track3;

    TrackPlacer trackPlacer;

    void Start()
    {
        trackPlacer = GetComponent<TrackPlacer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard.current.spaceKey.wasPressedThisFrame
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            Debug.Log("Pressed 1");
            trackPlacer.SpawnTrackPiece(track1);
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            Debug.Log("Pressed 2");
            trackPlacer.SpawnTrackPiece(track2);
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            Debug.Log("Pressed 3");
            trackPlacer.SpawnTrackPiece(track3);
        }
    }
}
