using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    public GameObject gameOverUI;
    public TextMeshProUGUI congratsText;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;

    public string mainMenuScene = "MainMenu";
    public string levelScene = "SampleScene";

    private bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    public void TriggerGameOver(bool won, int score, int highestCombo)
    {
        if (isGameOver) return;
        isGameOver = true;

        Time.timeScale = 0f;
        Debug.Log(" Game Over Menu activated");

        if (gameOverUI != null)
            gameOverUI.SetActive(true);
        else
            Debug.LogWarning(" GameOverUI not assigned in inspector!");

        if (resultText != null)
            resultText.text = won ? "Level Complete!" : "Game Over!";
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        if (comboText != null)
            comboText.text = "Highest Combo: x" + highestCombo;

        // Show "Congratulations!" only if level is completed
        if (congratsText != null)
            congratsText.gameObject.SetActive(won);
    }

    public void PlayAgain()
    {
        Debug.Log(" Play Again clicked");
        Time.timeScale = 1f;
        LevelEndZone.level = 1;
        SceneManager.LoadScene(levelScene);
    }

    public void ReturnToMainMenu()
    {
        Debug.Log(" Return to Main Menu clicked");
        Time.timeScale = 1f;
        LevelEndZone.level = 1;
        SceneManager.LoadScene(mainMenuScene);
    }
}
