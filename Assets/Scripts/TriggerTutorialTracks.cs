using UnityEngine;

public class TriggerTutorialTracks : MonoBehaviour
{
    [SerializeField] NewTrackPlacer newTrackPlacer;
    [SerializeField] GameObject tracksPreviewUI, canvasWorldTracksTutorial;
    PlayerController playerController;
    float enterSpeed;

    void Update()
    {
        if(playerController == null) { return; }

        if (Input.GetKeyDown(KeyCode.J))
        {
            playerController.Speed = enterSpeed;
            canvasWorldTracksTutorial.SetActive(false);
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            playerController.Speed = enterSpeed;
            canvasWorldTracksTutorial.SetActive(false);
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            playerController.Speed = enterSpeed;
            canvasWorldTracksTutorial.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerController>();
            enterSpeed = playerController.Speed;
            playerController.Speed = 0;
            tracksPreviewUI.SetActive(true);
            newTrackPlacer.SpawnRandomTracks(true);
        }
    }
}
