using TMPro;
using UnityEngine;

public class ScoreBillboard : MonoBehaviour
{
    private TMP_Text billboard;
    private int lastScore;

    private void Awake()
    {
        billboard = GetComponent<TMP_Text>();
        lastScore = 0;
    }

    private void Update()
    {
        if (lastScore == ScoreManager.score) return;
        billboard.SetText("Score: " + ScoreManager.score);
        lastScore = ScoreManager.score;
    }
}
