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
