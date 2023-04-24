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
using Unity.VisualScripting;
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
    [SerializeField] private TextMeshProUGUI _gradeText;

    [Header("Summary Information")]
    [SerializeField] private TextMeshProUGUI _summaryText;
    private int _unhomedAnimals;
/*   [SerializeField] private string _goodSummary;
    [SerializeField] private string _neutralSummary;
    [SerializeField] private string _badSummary;*/

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
    /// Restarts the current level
    /// </summary>
    public void RestartLevel()
    {
        GameController.main.CurrentLevelPoints.ResetStats();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

        _gradeText.text = "Grade: " + _levelPoints.FinalGrade.ToString();

        DisplaySummary();
    }

    /// <summary>
    /// Displays the summary based on how the levels destruction
    /// </summary>
    private void DisplaySummary()
    {
        CalcAnimalsUnhomed();

        if (_unhomedAnimals == 0)
        {
            _summaryText.text = "You managed to reach the end without destroying any trees! You saved all the animals!";
        }
        else if (_levelPoints.TreesChopped >= _levelPoints.TreesChoppedThreshhold * 2 ||
            _levelPoints.TreesBurntScore <= 10)
        {
            _summaryText.text = "You destroyed the homes of " + _unhomedAnimals + " animals.";
        }
        else if (_levelPoints.TreesChopped >= _levelPoints.TreesChoppedThreshhold * 3 ||
            _levelPoints.TreesBurntScore < 20)
        {
            _summaryText.text = "You left total destruction in your wake, destroying the homes of " + _unhomedAnimals;
        }
        else
        {
            _summaryText.text = "Deforestation removes carbon sinks and burning trees contributes to climate change. You've done both, you're an awful person.";
        }
    }

    /// <summary>
    /// Calculates semi random numbers of animals unhomed based on # of destroyed trees
    /// </summary>
    private void CalcAnimalsUnhomed()
    {
        _unhomedAnimals = (_levelPoints.TreesBurnt + _levelPoints.TreesChopped) * Random.Range(3, 4);
    }
}
