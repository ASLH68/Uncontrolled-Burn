/*****************************************************************************
// File Name :         PauseMenu.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 5th 12th, 2023
//
// Brief Description : This document controls the pause menu.
*****************************************************************************/
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu main;

    [Header("Panels")]
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private GameObject _howToPlayPanel;

    private bool _isPaused = false;
    public bool IsPaused => _isPaused;

    private GameObject _currentPanel;

    private void Awake()
    {
        if(main == null)
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
        _currentPanel = _pauseMenuPanel;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    /// <summary>
    /// Opens How To Play panel
    /// </summary>
    public void OpenHowToPlay()
    {
        SetCurrentPanel(_howToPlayPanel);
    }

    /// <summary>
    /// Activates the main menu panel
    /// </summary>
    public void BackToPauseScreen()
    {
        SetCurrentPanel(_pauseMenuPanel);
    }

    /// <summary>
    /// Closes current panel and opens new panel
    /// </summary>
    /// <param name="visible"></param>
    /// <param name="newPanel"></param>
    private void SetCurrentPanel(GameObject newPanel)
    {
        _currentPanel.SetActive(false);
        _currentPanel = newPanel;
        _currentPanel.SetActive(true);
    }

    /// <summary>
    /// Returns to the main menu
    /// </summary>
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Pauses the game
    /// </summary>
    /// <param name="scene"></param>
    public void PauseGame()
    {
        SetCurrentPanel(_pauseMenuPanel);
        LockPlayer();

        if (_isPaused)
        {
            _isPaused = false;
            _currentPanel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            _isPaused = true;
            Time.timeScale = 0f; 
        }      
    }

    /// <summary>
    /// Locks or unlocks the player movement
    /// </summary>
    private void LockPlayer()
    {
        if(_isPaused)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            FirstPersonController.main.IsControllable = true;
        }
        else
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            FirstPersonController.main.IsControllable = false;
        }
    }

    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
