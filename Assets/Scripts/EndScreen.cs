/*****************************************************************************
// File Name :         EndScreen.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 12th, 2023
//
// Brief Description : This document is the end screen when each level is completed
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public static EndScreen main;

    [SerializeField] private GameObject _nextLvlButton;

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
}
