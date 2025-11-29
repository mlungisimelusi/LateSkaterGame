using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;

    [Header("Combo Settings")]
    public float comboResetTime = 3f;

    [Header("Score Data")]
    public int currentScore = 0;
    public int coins = 0;
    public int comboCount = 0;
    public int highestCombo = 0;

    private float comboTimer = 0f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        // Handle combo reset
        if (comboCount > 0)
        {
            comboTimer -= Time.deltaTime;
            if (comboTimer <= 0f)
                ResetCombo();
        }
    }

    // Call this when the player does something good (collect, dodge, etc.)
    public void SuccessfulAction()
    {
        comboCount++;
        comboTimer = comboResetTime;

        if (comboCount > highestCombo)
            highestCombo = comboCount;

        float multiplier = 1f + (comboCount * 0.5f);
        int points = Mathf.RoundToInt(100 * multiplier);

        currentScore += points;
        UpdateUI();

        Debug.Log($"+{points} points | Combo x{comboCount} | Score: {currentScore}");
    }

    public void ResetCombo()
    {
        comboCount = 0;
        comboTimer = 0f;
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateUI();
    }

    public void RemoveScore(int amount)
    {
        currentScore = Mathf.Max(0, currentScore - amount);
        UpdateUI();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    public void SubtractCoins(int amount)
    {
        coins = Mathf.Max(0, coins - amount);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;
        if (coinText != null)
            coinText.text = "Coins: " + coins;
    }
}


