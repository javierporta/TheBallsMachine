using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; } = null;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text currentLevelText;

    [SerializeField]
    private GameObject levelDonePanel;

    [SerializeField]
    private GameObject virtualControl;

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

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateCurrentLevel(int currentLevel)
    {
        currentLevelText.text = $"Level {currentLevel}";
    }

    public void ShowLevelDonePanel(bool hasToShowLevel)
    {
        levelDonePanel.SetActive(hasToShowLevel);
    }

}
