using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float realDuration = 45f;      // Game lasts 45 real-time seconds
    private float elapsedTime = 0f;
    private bool timerRunning = true;

    private float scaleFactor = 20f;      // 15 min (900s) ÷ 45s = 20x speed

    void Update()
    {
        if (!timerRunning) return;

        elapsedTime += Time.deltaTime;

        float scaledElapsed = elapsedTime * scaleFactor;
        float remainingTime = Mathf.Max(900f - scaledElapsed, 0f); // 900 = 15 minutes in seconds

        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);

        timerText.text = $"{minutes:D2}:{seconds:D2}";

        if (elapsedTime >= realDuration)
        {
            timerRunning = false;
            Debug.Log("Timer Ended!");
            // Add your Game Over or end-of-time logic here
        }
    }
}