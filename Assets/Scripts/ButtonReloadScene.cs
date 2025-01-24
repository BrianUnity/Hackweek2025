using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReloadScene : MonoBehaviour
{
    void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }); 
    }
}
