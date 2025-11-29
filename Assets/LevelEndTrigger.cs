using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(" Trigger entered by: " + other.name); // This fires on ANY object

        if (other.CompareTag("Player"))
        {
            Debug.Log(" Player entered the LevelEndTrigger");

            if (ScoreManager.instance == null)
                Debug.LogWarning(" ScoreManager.instance is NULL!");

            if (GameOverManager.instance == null)
                Debug.LogWarning(" GameOverManager.instance is NULL!");

            if (ScoreManager.instance != null && GameOverManager.instance != null)
            {
                Debug.Log(" Calling TriggerGameOver()");
                GameOverManager.instance.TriggerGameOver(
                    won: true,
                    score: ScoreManager.instance.currentScore,
                    highestCombo: ScoreManager.instance.highestCombo
                );
            }
        }
    }
}