using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] TheBestCharacterController _theBestCharacterController;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => { _theBestCharacterController.Run(); });
    }
}
