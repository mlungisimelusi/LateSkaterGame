using UnityEngine;
using TMPro;

public class LevelEndZone : MonoBehaviour
{
    public static int level = 1; // Global level counter
    public TextMeshProUGUI levelText; // Assign in Inspector

    private void Start()
    {
        UpdateLevelUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            level += 1;
            Debug.Log("Level Reached: " + level);
            UpdateLevelUI();
        }
    }

    void UpdateLevelUI()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + level;
        }
    }
}