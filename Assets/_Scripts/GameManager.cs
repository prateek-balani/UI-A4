using TMPro;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private CoinCounterUI coinCounter;

    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (coinCounter == null)
        {
            Debug.LogWarning("CoinCounterUI is not assigned in the GameManager.");
        }

        if (scoreText == null)
        {
            Debug.LogWarning("ScoreText is not assigned in the GameManager.");
        }
    }

    public void IncreaseScore()
    {
        score++;
        coinCounter.UpdateScore(score);
        scoreText.text = $"Score: {score}";
        
    }
}
