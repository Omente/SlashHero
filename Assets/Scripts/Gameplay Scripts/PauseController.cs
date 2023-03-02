using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private void Awake()
    {
        pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(TagManager.SCENE_NAME_GAMEPLAY);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {

    }

    
}
