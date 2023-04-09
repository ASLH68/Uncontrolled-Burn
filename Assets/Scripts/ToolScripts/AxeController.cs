/*****************************************************************************
// File Name :         AxeController.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 9th, 2023
//
// Brief Description : This document controls the axe attack.
*****************************************************************************/

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
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canAttack)
        {
            AxeAttack();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("WallSegment") || other.CompareTag("FireResistant")) && _isAttacking)
        {
            other.GetComponent<Animator>().SetTrigger("Hit");
            other.GetComponent<WallSegment>().LoseHealth(_attackDamage, true);    
        }
    }

    /// <summary>
    /// Begins the axe attack trigger
    /// </summary>
    public void AxeAttack()
    {
        _isAttacking = true;
        _canAttack = false;
        Animator anim = _axe.GetComponent<Animator>();
        anim.SetTrigger("Attack");

        StartCoroutine(ResetAttackCooldown());
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
    }


}
