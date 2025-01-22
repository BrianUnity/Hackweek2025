using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] private List<Text> texts = new List<Text>();
    [SerializeField] private List<Button> buttons = new List<Button>();
    [SerializeField] private List<Image> images = new List<Image>();

    public void Show(PopUpData popUpData, float delayAutoClose = 0)
    {
        gameObject.SetActive(true);

        for (int i = 0; i < popUpData.messages.Count; i++) { texts[i].text = popUpData.messages[i]; }
        for (int i = 0; i < popUpData.unityEvents.Count; i++)
        {
            buttons[i].gameObject.SetActive(true);
            buttons[i].onClick.AddListener(popUpData.unityEvents[i].Invoke);
            buttons[i].onClick.AddListener(Close);
        }

        for (int i = 0; i < popUpData.sprites.Count; i++) { images[i].sprite = popUpData.sprites[i]; }
        if (delayAutoClose.Equals(0)) { return; }
        StartCoroutine(WaitForClose(delayAutoClose));
    }

    IEnumerator WaitForClose(float delayAutoClose)
    {
        yield return new WaitForSeconds(delayAutoClose);
        Close();
    }

    public void Close()
    {
        for (int i = 0; i < texts.Count; i++) { texts[i].text = string.Empty; }
        for (int i = 0; i < buttons.Count; i++) { buttons[i].onClick.RemoveAllListeners(); buttons[i].gameObject.SetActive(false); }
        for (int i = 0; i < images.Count; i++) { images[i].sprite = null; }
        gameObject.SetActive(false);
    }
}
