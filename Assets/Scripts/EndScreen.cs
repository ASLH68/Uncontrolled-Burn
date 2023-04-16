/*****************************************************************************
// File Name :         EndScreen.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 12th, 2023
//
// Brief Description : This document is the end screen when each level is completed
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public static EndScreen main;

    [SerializeField] private GameObject _nextLvlButton;

    [SerializeField]private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _burntTreesText;
    [SerializeField] private TextMeshProUGUI _choppedTreesText;
    [SerializeField] private TextMeshProUGUI _timeText;

    private LevelPoints _levelPoints;   // scriptable object to use when displaying stats

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        _scoreText = GameObject.Find("Score Stat").GetComponentInChildren<TextMeshProUGUI>();
        _burntTreesText = GameObject.Find("Tree Burnt Stat").GetComponentInChildren<TextMeshProUGUI>();
        _choppedTreesText = GameObject.Find("Tree Axe Stat").GetComponentInChildren<TextMeshProUGUI>();
        _timeText = GameObject.Find("Time Stat").GetComponentInChildren<TextMeshProUGUI>();
        CheckLastLevel();
    }

    /// <summary>
    /// Returns to main menu
    /// </summary>
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// If it's the last level, the next button disappears
    /// </summary>
    public void CheckLastLevel()
    {
        if(SceneManager.sceneCountInBuildSettings - 1 == SceneManager.GetActiveScene().buildIndex)
        {
            HideNextLevelButton();
        }
    }

    /// <summary>
    /// Loads the next level in build
    /// </summary>
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Hides the next level button
    /// </summary>
    private void HideNextLevelButton()
    {
        _nextLvlButton.SetActive(false);
    }

    /// <summary>
    /// Sets the instance of levelPoints used to display player/level stats
    /// </summary>
    /// <param name="levelPoints"></param>
    private void SetLevelPoints()
    {
        _levelPoints = GameController.main.CurrentLevelPoints;
    }

    /// <summary>
    /// Calls the data helper functions for display
    /// </summary>
    public void DisplayData()
    {
        SetLevelPoints();

        _scoreText.text = "Score: " + _levelPoints.Score + " / " + _levelPoints.DefaultScore;
        _burntTreesText.text = "Trees Burnt Down: " + _levelPoints.TreesBurnt;
        _choppedTreesText.text = "Trees Chopped Down: " + _levelPoints.TreesChopped;
        _timeText.text = "Time: " + GameController.main.CurrentTimer.GetTime();
    }
}
