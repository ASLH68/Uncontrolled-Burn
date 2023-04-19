/*****************************************************************************
// File Name :         FireSoundManager.cs
// Author :            Peter Campbell
// Creation Date :     April 19th, 2023
//
// Brief Description : This script plays a fire sound when any tree is lit
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSoundManager : MonoBehaviour
{
    AudioSource _audioSource;
    int _treesOnFire;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Activates sound if any tree is on fire
    /// </summary>
    private void FixedUpdate()
    {
        // Detects if trees are lit
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("WallSegment"))
        {
            if (i.GetComponent<WallSegment>().IsOnFire)
            {
                _treesOnFire++;
                Debug.Log("trees");
            }

        }

        // Determines whether to play sound
        if (_treesOnFire > 0 && !_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
        if (_audioSource.isPlaying && _treesOnFire == 0)
        {
            _audioSource.Stop();
        }

        _treesOnFire = 0;
    }
}
