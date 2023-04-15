/*****************************************************************************
// File Name :         LevelPoints.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 14th, 2023
//
// Brief Description : This document is a scriptable object that holds each
                       level's stat data.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(fileName = "Star Rating", menuName = "Star Rating")]
public class LevelPoints : ScriptableObject
{
    [SerializeField] private int _defaultScore = 100;   // Starting / Max points

    [SerializeField] private int _treesDestroyed;   // num trees destroyed
    [SerializeField] private int _pointsPerTree;    // points lost per tree

    private int _score;     // Final score

    public int TreesDestroyed => _treesDestroyed;

    private void Awake()
    {
        _score = _defaultScore;
    }

    /// <summary>
    /// Increments the number of trees destroyed that playthrough
    /// </summary>
    public void DestroyTree()
    {
        _treesDestroyed++;
    }

    /// <summary>
    /// Calculates the score based on the stats accumulated throughout the level
    /// </summary>
    public void CalculateScore()
    {
        _score -= _treesDestroyed * _pointsPerTree;
    }

/*    /// <summary>
    /// Resets 
    /// </summary>
    private void OnDisable()
    {
        _treesDestroyed = 0;
    }*/
}
