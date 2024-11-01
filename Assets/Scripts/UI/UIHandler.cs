using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    private ScoreManager scoreManager;
    [SerializeField]
    private Text ScoreText;
    [SerializeField]
    private Text HighscoreText;
    [SerializeField]
    private Text CurrentplayerName;


    private void OnEnable()
    {
        scoreManager = ScoreManager.Instance;
        if (scoreManager != null)
        {
            scoreManager.ScoreChanged += OnUpdateScore;
            scoreManager.HighscoreUpdated += OnUpdateHighscore;
            scoreManager.ResetScore();

        }
        else
        {
            Debug.LogError("ScoreManager not found!");
            return;
        }
    }

    private void OnDisable()
    {
        if (scoreManager != null)
        {
            scoreManager.ScoreChanged -= OnUpdateScore;
            scoreManager.HighscoreUpdated -= OnUpdateHighscore;
        }
    }
    void Start()
    {
        OnUpdateHighscore();
        CurrentPlayerNameSet();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnUpdateScore(int score)
    {
        ScoreText.text = $"Score : {score}";
    }

    void OnUpdateHighscore()
    {
        if (HighscoreText != null && DataManager.Instance != null)
        {
            string highscores = DataManager.Instance.GetFormattedHighscores();
            HighscoreText.text = $"Highscores:\n{highscores}";
        }
    }

    void CurrentPlayerNameSet()
    {
        if (CurrentplayerName != null && DataManager.Instance != null)
        {
            CurrentplayerName.text = $"Player Name: {DataManager.Instance.currentPlayerId}";
        }
    }
}
