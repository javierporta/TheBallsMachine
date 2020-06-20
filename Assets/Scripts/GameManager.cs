using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;
    private int score = 0;
    private int currentLevelScore = 0;

    private int level = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateGameScoreText();
        UpdateGameCurrentLevel();
    }

    private void UpdateGameScoreText()
    {
        UIManager.Instance.UpdateScore(score);
    }

    private void UpdateCurrentLevelScoreText()
    {
        UIManager.Instance.UpdateCurrentLevelScore(currentLevelScore);
    }

    private void UpdateGameCurrentLevel()
    {
        UIManager.Instance.UpdateCurrentLevel(level);
    }

    public void AddScore(int scoreToAdd)
    {
        if (scoreToAdd > 0)
        {
            //Total score
            score += scoreToAdd;
            UpdateGameScoreText();

            //Current level score
            currentLevelScore += scoreToAdd;
            UpdateCurrentLevelScoreText();
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateGameScoreText();
    }

    public void ResetCurrentLevelScore()
    {
        currentLevelScore = 0;
        UpdateCurrentLevelScoreText();
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        UIManager.Instance.ShowLevelDonePanel(false);
        CancelLastGameScore();
        ResetCurrentLevelScore();
    }

    private void CancelLastGameScore()
    {
        //get back to initial score
        score = score - currentLevelScore;
        UpdateGameScoreText();
    }

    public void NextLevel()
    {
        level++;
        SceneManager.LoadSceneAsync($"Level{level}Scene");
        UIManager.Instance.ShowLevelDonePanel(false);
        UIManager.Instance.UpdateCurrentLevel(level);
        ResetCurrentLevelScore();
    }

    public void CheckIfLevelHasFinished()
    {
        if (MainBall.Instance.HasBallFellDown && ObjectPoolManager.Instance.AreAllSpawnedBallsInactive())
        {
            print("Level finished");

            if (level == 3)
            {
                UIManager.Instance.ShowGameCompletedPanel(true);
                UIManager.Instance.UpdateFinalScore(score);
            }
            else
            {
                UIManager.Instance.ShowLevelDonePanel(true);
            }
            
        }
    }

    public void StartGame()
    {
        level = 1;
        SceneManager.LoadSceneAsync($"Level{level}Scene");
        UIManager.Instance.ShowLevelDonePanel(false);
        UIManager.Instance.UpdateCurrentLevel(level);
        UIManager.Instance.ShowHud(true);
        ResetScore();
        ResetCurrentLevelScore();
    }

    public void GoToMainMenu()
    {
        UIManager.Instance.ShowGameCompletedPanel(false);
        UIManager.Instance.ShowHud(false);
        SceneManager.LoadSceneAsync("MenuScene");
    }
}
