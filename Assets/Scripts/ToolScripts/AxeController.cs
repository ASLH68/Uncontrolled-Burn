/*****************************************************************************
// File Name :         AxeController.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 9th, 2023
//
// Brief Description : This document controls the axe attack.
*****************************************************************************/

using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    public static AxeController main;

    [SerializeField] private GameObject _axe;
    [SerializeField] private bool _canAttack = true; // can only attack if true
    [SerializeField] private float _attackCooldown = 2.8f;
    [SerializeField] private bool _isAttacking = false;
    [SerializeField] private int _attackDamage;
    [SerializeField] private Collider _axeCollider;
    [SerializeField] private AudioSource _axeHitSound;
    private bool _hasHit = false;

    private PlayerControls playerActions;

    private void Awake()
    {
        if(main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }

        playerActions = new PlayerControls();
    }

    private void Start()
    {
        _axeCollider.enabled = false;
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canAttack)
        {
            AxeAttack();
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("WallSegment") || other.CompareTag("FireResistant")) && _isAttacking && !_hasHit)
        {
            other.GetComponent<Animator>().SetTrigger("Hit");
            other.GetComponent<WallSegment>().LoseHealth(_attackDamage, true);
            _hasHit = true;
            PlayHitSound();
            DisableColliders();
        }
    }

    /// <summary>
    /// Begins the axe attack trigger
    /// </summary>
    public void AxeAttack()
    {
        if(_canAttack)
        {
            Invoke("EnableColliders", 0.75f);
            _isAttacking = true;
            _canAttack = false;
            Animator anim = _axe.GetComponent<Animator>();
            anim.SetTrigger("Attack");
            StartCoroutine(ResetAttackCooldown());
        }
    }

    /// <summary>
    /// Sets the _canAttack var to true once the attack cooldown is over
    /// </summary>
    /// <returns></returns>
    IEnumerator ResetAttackCooldown()
    {       
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
        _isAttacking = false;
        _axeCollider.enabled = false;
        _hasHit = false;
    }

    /// <summary>
    /// Plays the axe hit sound
    /// </summary>
    private void PlayHitSound()
    {
        if (_hasHit)
        {
            _axeHitSound.Play();
        }
    }

    /// <summary>
    /// Enables the axe collider
    /// </summary>
    private void EnableColliders()
    {
        _axeCollider.enabled = true;
    }

    private void DisableColliders()
    {
        _axeCollider.enabled = false;
    }

    /// <summary>
    /// Resets the axe cooldown in case it gets cancelled mid swing
    /// </summary>
    public void ResetAxeState()
    {
        _canAttack = true;
        _isAttacking = false;
        _axeCollider.enabled = false;
        _hasHit = false;
        DisableColliders();
    }

    private void OnEnable()
    {
        playerActions.Enable();

        playerActions.Player.AbilityUse.performed += ctx => AxeAttack();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }
}
