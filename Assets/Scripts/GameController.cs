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
            FirstPersonController.main.IsControllable = false;
        }
    }

    public void DisplayEndScreen()
    {
        _endScreen.SetActive(true);
    }
}
