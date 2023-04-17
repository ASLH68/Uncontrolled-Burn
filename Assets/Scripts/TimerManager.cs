/*****************************************************************************
// File Name :         TimerManagerr.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 15th, 2023
//
// Brief Description : This document controls a timer feature.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float _currentTime;
    public bool _countDown = false;
    public bool IsRunning = true;

    [Header("Format Settings")]
    [SerializeField] private TimerFormats _format = TimerFormats.TENTH;
    private Dictionary<TimerFormats, string> _timeFormats = new Dictionary<TimerFormats, string>();

    public float FinalTime => _currentTime;

    private void Start()
    {
        _timeFormats.Add(TimerFormats.NONE, "");
        _timeFormats.Add(TimerFormats.WHOLE, "0");
        _timeFormats.Add(TimerFormats.TENTH, "0.0");
        _timeFormats.Add(TimerFormats.HUNDRETH, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRunning)
        {
            _currentTime = _countDown ? _currentTime -= Time.deltaTime : _currentTime += Time.deltaTime;
        }
    }

    /// <summary>
    /// Gets the _currentTime variable with instance-unique formatting
    /// </summary>
    /// <returns></returns>
    public string GetTime()
    {
        return _currentTime.ToString(_timeFormats[_format]);
    }

    public void ResetTime()
    {
        _currentTime = 0.0f;
    }
}

public enum TimerFormats
{
    NONE,
    WHOLE,
    TENTH,
    HUNDRETH
}
