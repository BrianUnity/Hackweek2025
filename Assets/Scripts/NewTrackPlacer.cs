using System.Collections.Generic;
using UnityEngine;

public class NewTrackPlacer : MonoBehaviour
{
    [SerializeField] Track initialTrack;
    [SerializeField] Transform player, spawnYellow, spawnCyan, spawnPink;
    [SerializeField] float distanceToPlaceTrack = 2f;
    [SerializeField] List<Track> tracks = new List<Track>();
    Vector3 lastTrackEndAnchorPosition;
    bool isTutorial = true;
    Track trackYellow, trackCyan, trackPink;

    void Awake()
    {
        lastTrackEndAnchorPosition = initialTrack.EndAnchorPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            RepositionTrack("Yellow");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            RepositionTrack("Cyan");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            RepositionTrack("Pink");
        }
    }

    void SpawnTrackPiece(Track trackPrefab)
    {
        if(Vector2.Distance(player.position, lastTrackEndAnchorPosition) > distanceToPlaceTrack)
        {
            Debug.Log("Too far away to place a track!");
            return;
        }
    }

    Track SpawnTrack(Track trackPrefab, Vector3 position, Color color)
    {
        Track newTrack = Instantiate(trackPrefab, position, trackPrefab.transform.rotation);
        newTrack.Color = color;
        newTrack.gameObject.SetActive(true);
        return newTrack;
    }

    public void SpawnRandomTracks(bool isTutorial = false)
    {
        trackYellow = SpawnTrack(tracks[isTutorial ? 0 : Random.Range(0, tracks.Count)], spawnYellow.position, Color.yellow);
        trackCyan = SpawnTrack(tracks[isTutorial ? 0 : Random.Range(0, tracks.Count)], spawnCyan.position, Color.cyan);
        trackPink = SpawnTrack(tracks[isTutorial ? 0 : Random.Range(0, tracks.Count)], spawnPink.position, Color.magenta);
    }

    void RepositionTrack(string textColor)
    {
        if (Vector2.Distance(player.position, lastTrackEndAnchorPosition) > distanceToPlaceTrack)
        {
            Debug.Log("Too far away to place a track!");
            return;
        }

        if (textColor == "Yellow")
        {
            lastTrackEndAnchorPosition.z = 1;
            trackYellow.transform.position = lastTrackEndAnchorPosition;
            lastTrackEndAnchorPosition = trackYellow.EndAnchorPosition;
            Destroy(trackCyan.gameObject);
            Destroy(trackPink.gameObject);
        }

        if (textColor == "Cyan")
        {
            lastTrackEndAnchorPosition.z = 0;
            trackCyan.transform.position = lastTrackEndAnchorPosition;
            lastTrackEndAnchorPosition = trackCyan.EndAnchorPosition;
            Destroy(trackYellow.gameObject);
            Destroy(trackPink.gameObject);
        }

        if (textColor == "Pink")
        {
            lastTrackEndAnchorPosition.z = -1;
            trackPink.transform.position = lastTrackEndAnchorPosition;
            lastTrackEndAnchorPosition = trackPink.EndAnchorPosition;
            Destroy(trackYellow.gameObject);
            Destroy(trackCyan.gameObject);
        }

        SpawnRandomTracks();
    }
}
