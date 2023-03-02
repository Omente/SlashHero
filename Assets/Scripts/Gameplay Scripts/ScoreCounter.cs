using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int scoreCount;
    public int ScoreCount
    {
        get { return scoreCount; }
    }
    private float scoreCountTimerTreshold = 1f;
    private float scoreCountTimer;
    private bool canCountScore;
    public bool CanCountScore 
    {
        get { return canCountScore; }
        set { canCountScore = value; } 
    }
    private StringBuilder stringBuilder = new StringBuilder();

    private void Awake()
    {
        scoreCount = 0;
        scoreCountTimer = Time.time + scoreCountTimerTreshold;
        CanCountScore = true;
    }

    private void Update()
    {
        ProccesScoreCounting();
    }

    private void ProccesScoreCounting()
    {
        if (((Time.time < scoreCountTimer) && CanCountScore) || !CanCountScore)
            return;

        scoreCountTimer = Time.time + scoreCountTimerTreshold;

        CountScore();
        UpdateText();
    }

    private void CountScore()
    {
        scoreCount++;
    }

    private void UpdateText()
    {
        stringBuilder.Clear();
        stringBuilder.Append($"{scoreCount}M");
        scoreText.text = stringBuilder.ToString();
    }

}
