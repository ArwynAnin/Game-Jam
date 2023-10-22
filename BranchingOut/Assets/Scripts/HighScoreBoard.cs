using TMPro;
using UnityEngine;

public class HighScoreBoard : MonoBehaviour
{
    private TMP_Text billboard;

    private void Awake()
    {
        billboard = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        billboard.text = ScoreManager.highScore.ToString();
    }
}
