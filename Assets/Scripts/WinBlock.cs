/*****************************************************************************
// File Name :         WinBlock.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 12th, 2023
//
// Brief Description : This document controls the win block that triggers the
                       end of each level.
*****************************************************************************/
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBlock : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            FirstPersonController.main.IsControllable = false;

            GameController.main.DisplayEndScreen();
        }
    }
}
