using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AudioSource backgroundMusic;

    public TMP_Text scoreText;
    public TMP_Text gameOverText;
    public TMP_Text startText;
    public TMP_Text winText;

    //private int score = 0;
    public bool gameActive = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (scoreText == null)
            scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        if (startText == null)
            startText = GameObject.Find("StartText").GetComponent<TMP_Text>();
        if (gameOverText == null)
            gameOverText = GameObject.Find("GameOverText").GetComponent<TMP_Text>();
        if (winText == null)
            winText = GameObject.Find("WinText").GetComponent<TMP_Text>();

        Time.timeScale = 0f;
        startText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        scoreText.text = "Score: 0";

    }

    void Update()
    {
        if (!gameActive && Input.anyKeyDown && !gameOverText.gameObject.activeSelf)
        {
            StartGame();
        }

        // ✅ Restart the game when 'R' is pressed and Game Over is showing
        if (gameOverText.gameObject.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        else if (winText.gameObject.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        // You can reload the current scene to start fresh
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }


    public void StartGame()
    {
        gameActive = true;
        Time.timeScale = 1f;
        startText.gameObject.SetActive(false);
    }

    //public void IncreaseScore()
    //{
    //    score++;
    //    scoreText.text = "Score: " + score;
    //}

    public void GameOver()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop(); // or .Pause() if you want to resume later
        }
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public IEnumerator WinGameAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        WinGame();
    }
    public void WinGame()
    {
        winText.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
