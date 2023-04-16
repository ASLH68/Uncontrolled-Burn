/*****************************************************************************
// File Name :         LevelPoints.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 14th, 2023
//
// Brief Description : This document is a scriptable object that holds each
                       level's stat data and point calculations.
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

    [SerializeField] private int _treesBurnt;   // num trees destroyed by fire
    [SerializeField] private int _treesChopped; // num trees chopped
    [SerializeField] private int _pointsPerBurntTree;    // points lost per tree

    [SerializeField] [Tooltip("Points that will be deducted if the tree chopped threshhold is met")] 
    private int _pointsPerTreesChopped = 0;

    [SerializeField] [Tooltip("number of trees that must be destroyed by an axe in order to lose x amount of points")]
    private int _treesChoppedThreshhold = 0;
    
    [SerializeField] [Tooltip("Points that will be deducted if the tree chopped threshhold is met")] 
    private int _pointsPerTimeMet = 10;

    [SerializeField] [Tooltip("number of trees that must be destroyed by an axe in order to lose x amount of points")]
    private float _timeThreshhold = 30;

    private int _score;     // Final score

    public int Score => _score;
    public int DefaultScore => _defaultScore;
    public int TreesBurnt => _treesBurnt;
    public int TreesChopped => _treesChopped;

    private void Awake()
    {
        _score = _defaultScore;
    }

    /// <summary>
    /// Increments the number of trees destroyed by fire
    /// </summary>
    public void BurnTree()
    {
        _treesBurnt++;
    }

    /// <summary>
    /// Increments the number of trees destroyed by axe
    /// </summary>
    public void ChopTree()
    {
        _treesChopped++;
    }

    /// <summary>
    /// Calculates the score based on the stats accumulated throughout the level
    /// </summary>
    public void CalculateScore()
    {
        _score -= _treesBurnt * _pointsPerBurntTree;
        
        // Calculates how many points are reduced if enough trees are cut down
        if((int)(_treesChopped/_treesChoppedThreshhold) > 0)
        {
            _score -= (int)(_treesChopped / _treesChoppedThreshhold) * _pointsPerTreesChopped;
        }

        // Calculates how many points a reduced based on how long the player took to beat the level
        if(GameController.main.CurrentTimer.FinalTime / _timeThreshhold > 0)
        {
            _score -= (int)(GameController.main.CurrentTimer.FinalTime / _timeThreshhold) * _pointsPerTimeMet;
        }
        
    }

    /// <summary>
    /// Resets values
    /// </summary>
    private void OnDisable()
    {
        _treesBurnt = 0;
        _treesBurnt = 0;
    }
}
