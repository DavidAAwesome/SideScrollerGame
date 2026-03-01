using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("Scoring")]
    [SerializeField] private float pointsPerSecond = 10f;
    [SerializeField] private int bananaValue = 50;

    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bananasText; // optional

    public int CurrentScore { get; private set; }
    public int BananasCollected { get; private set; }
    public bool IsRunning { get; private set; }

    private float scoreFloat;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    private void Update()
    {
        if (!IsRunning) return;

        scoreFloat += pointsPerSecond * Time.deltaTime;
        CurrentScore = Mathf.FloorToInt(scoreFloat);

        UpdateUI();
    }

    public void StartRun()
    {
        IsRunning = true;
        scoreFloat = 0f;
        CurrentScore = 0;
        BananasCollected = 0;
        UpdateUI();
    }

    public void AddBanana(int amount = 1)
    {
        BananasCollected += amount;
        UpdateUI();
    }

    /// Call this once when you die/end the run
    public int EndRunAndFinalizeScore()
    {
        IsRunning = false;

        int bananaPoints = BananasCollected * bananaValue;
        CurrentScore += bananaPoints;

        UpdateUI();
        return CurrentScore;
    }

    private void UpdateUI()
    {
        if (scoreText) scoreText.text = $"Score: {CurrentScore}";
        if (bananasText) bananasText.text = $"Bananas: {BananasCollected}";
    }
}