using UnityEngine;
using TMPro;

public class MysteryBoxMessageManager : MonoBehaviour
{
    public static MysteryBoxMessageManager instance;
    public TextMeshProUGUI messageText;
    public float displayDuration = 2f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        if (messageText != null)
            messageText.gameObject.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        StopAllCoroutines(); // If a previous message is showing
        StartCoroutine(DisplayMessage(message));
    }

    System.Collections.IEnumerator DisplayMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayDuration);
        messageText.gameObject.SetActive(false);
    }
}
