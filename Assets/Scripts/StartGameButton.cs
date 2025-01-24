using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => { _playerController.Speed = 2; });
    }
}
