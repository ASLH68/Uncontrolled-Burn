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

    PlayerControls playerActions;

    /// <summary>
    /// Grabs a playercontrols map, tbh idk what this actually does...
    /// </summary>
    private void Awake()
    {
        playerActions = new PlayerControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void WillItFire()
    {
        if(!PauseMenu.main.IsPaused)
        {
            CastFire();
        }
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
            _fpsCon.MoveSpeed = _fpsCon.DefaultMoveSpeed;
            _fpsCon.SprintSpeed = _fpsCon.DefaultSprintSpeed;
            _audioSource.Stop();
        }
        else
        {
            _fireCone.SetActive(true);
            _fpsCon.MoveSpeed = _fpsCon.FTMoveSpeed;
            _fpsCon.SprintSpeed = _fpsCon.FTSprintSpeed;
            _audioSource.Play();
        }
    }

    /// <summary>
    /// This enables player controls, specifically the one where the player shoots fire
    /// </summary>
    private void OnEnable()
    {
        playerActions.Enable();

        playerActions.Player.AbilityStartAndRelease.performed += ctx => WillItFire();
    }

    /// <summary>
    /// This removes the flamethrower cone, it sets the speeds to default, it turns off the sound, and it disables player controls
    /// </summary>
    private void OnDisable()
    {
        _fireCone.SetActive(false);
        _fpsCon.MoveSpeed = _fpsCon.DefaultMoveSpeed;
        _fpsCon.SprintSpeed = _fpsCon.DefaultSprintSpeed;
        _audioSource.Stop();

        playerActions.Disable();
    }
}
