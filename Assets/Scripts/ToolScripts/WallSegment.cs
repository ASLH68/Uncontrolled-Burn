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
    /// Destroys the wall segment
    /// </summary>
    private void DestroySegment()
    {
        Destroy(gameObject);
    }
}
