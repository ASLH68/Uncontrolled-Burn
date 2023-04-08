/*****************************************************************************
// File Name :         WallSegment.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 5th, 2023
//
// Brief Description : This document controls the wall segments
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSegment : MonoBehaviour
{
    [SerializeField] private int _health;
    private bool _isResistant = false;  // If wall is resistant to fire

    public bool IsResistant => _isResistant;

    /// <summary>
    /// Tree loses health
    /// </summary>
    public void LoseHealth(int healthLost)
    {
        _health -= healthLost;

        if(_health <= 0)
        {
            DestroySegment();
        }
    }

    /// <summary>
    /// Sets _isResistant to true
    /// </summary>
    public void SetIsResistant()
    {
        _isResistant = true;
    }

    /// <summary>
    /// Destroys the wall segment
    /// </summary>
    private void DestroySegment()
    {
        Destroy(gameObject);
    }
}
