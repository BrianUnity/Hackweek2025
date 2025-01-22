using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActiveGameObjects : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjectsToActive, gameObjectsToInactive;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            for (int i = 0; i < gameObjectsToActive.Count; i++) { gameObjectsToActive[i].SetActive(true); }
            for (int i = 0; i < gameObjectsToInactive.Count; i++) { gameObjectsToInactive[i].SetActive(false); }
        });
    }
}