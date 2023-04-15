/*****************************************************************************
// File Name :         Game Controller.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 5th, 2023
//
// Brief Description : This document is the game controller
*****************************************************************************/
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController main;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private LevelPoints _levelPoints;

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
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene != 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            FirstPersonController.main.IsControllable = true;
        }
    }

    /// <summary>
    /// Displays the end-level screen
    /// </summary>
    public void DisplayEndScreen()
    {
        _endScreen.SetActive(true);
        _levelPoints.CalculateScore();
        EndScreen.main.GetComponent<EndScreen>().SetLevelPoints(_levelPoints);
    }

    /// <summary>
    /// Increments destroyed trees by 1
    /// </summary>
    public void DestroyTree()
    {
        _levelPoints.DestroyTree();
    }
}
