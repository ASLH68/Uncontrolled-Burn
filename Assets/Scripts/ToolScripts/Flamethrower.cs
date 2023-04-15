/*****************************************************************************
// File Name :         Flamethrower.cs
// Author :            Peter Campbell
// Creation Date :     April 5th, 2023
//
// Brief Description : Functionality of the flamethrower
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class Flamethrower : MonoBehaviour
{
    [SerializeField] GameObject _fireCone;
    [SerializeField] FirstPersonController _fpsCon;
    AudioSource _audioSource;

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
    /// Controls generation of fire object
    /// </summary>
    /// <param name="FireCone">object that determines fires position</param>
    public void CastFire()
    {
        if (_fireCone.activeInHierarchy)
        {
            _fireCone.SetActive(false);
        }
        else
        {
            _fireCone.SetActive(true);
        }
    }

    /// <summary>
    /// Called when object is disabled
    /// </summary>
    private void OnDisable()
    {
        _fireCone.SetActive(false);
    }
}
