using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private TextMeshProUGUI currentScore, bestScore;
    
    private ScoreCounter scoreCounter;
    private StringBuilder stringBuilder = new StringBuilder();

    private void Awake()
    {
        scoreCounter = gameObject.GetComponent<ScoreCounter>();

        gameOverCanvas.enabled = false;
    }

    public void ShowGameOverCanvas()
    {
        scoreCounter.CanCountScore = false;

        gameOverCanvas.enabled = true;

        DispalyScore();
        CheackNewHighscore();
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(TagManager.SCENE_NAME_GAMEPLAY);
    }

    public void ExitGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(TagManager.SCENE_NAME_MAIN_MENU);
    }

    private void DispalyScore()
    {
        stringBuilder.Clear();
        stringBuilder.Append($"Score: {scoreCounter.ScoreCount}M");
        currentScore.text = stringBuilder.ToString();
    }

    private void CheackNewHighscore()
    {
        stringBuilder.Clear();

        int currentBestScore = DataManager.GetData(TagManager.DATA_HIGHSCORE);
        int newScore = scoreCounter.ScoreCount;

        if (newScore > currentBestScore)
        {
            DataManager.SaveData(TagManager.DATA_HIGHSCORE, newScore);
            stringBuilder.Append($"HIGHSCORE: {newScore}M");
            bestScore.text = stringBuilder.ToString();
        }
        else
        {
            stringBuilder.Append($"HIGHSCORE: {currentBestScore}M");
            bestScore.text = stringBuilder.ToString();
        }
        GameplayController.instance.CheackToUnlockCharacter(DataManager.GetData(TagManager.DATA_HIGHSCORE));
    }

}