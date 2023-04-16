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

    [SerializeField] private TimerManager _timerManager;    // Per level timer

    public TimerManager CurrentTimer => _timerManager;

    public LevelPoints CurrentLevelPoints => _levelPoints;

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
        _timerManager.IsRunning = false;
        _endScreen.SetActive(true);
        _levelPoints.CalculateScore();
        EndScreen.main.GetComponent<EndScreen>().DisplayData();
    }

    /// <summary>
    /// Increments destroyed trees by 1
    /// </summary>
    /// <param name="isOnFire"> T = Increments burnt trees if the tree was on fire </param>
    public void DestroyTree(bool isOnFire)
    {
        if(isOnFire)
        {
            _levelPoints.BurnTree();
        }
        else
        {
            _levelPoints.ChopTree();
        }
       
    }
}
