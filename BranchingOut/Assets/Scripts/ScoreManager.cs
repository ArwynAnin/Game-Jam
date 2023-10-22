using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int highScore;

    private void Awake()
    {
        highScore = (PlayerPrefs.HasKey("highScore")) ? PlayerPrefs.GetInt("highScore") : 0;
    }

    private void Update()
    {
        if (score < highScore) return;
        highScore = score;
        PlayerPrefs.SetInt("highScore", highScore);
    }
}
