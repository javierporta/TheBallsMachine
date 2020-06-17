using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;
    private int score = 0;

    private int level = 1;

    public bool IsPaused { get; private set; } = false;

    private float oldTimeScale;

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

    private void UpdateGameCurrentLevel()
    {
        UIManager.Instance.UpdateCurrentLevel(level);
    }

    public void AddScore(int scoreToAdd)
    {
        if (scoreToAdd > 0)
        {
            score += scoreToAdd;
            UpdateGameScoreText();
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateGameScoreText();
    }

    public void CheckIfLevelHasFinished()
    {
        if (MainBall.Instance.HasBallFellDown && ObjectPoolManager.Instance.AreAllSpawnedBallsInactive())
        {
            print("Level finished");
            //ToDo: show menu with results > next level | restart
        }
    }
}
