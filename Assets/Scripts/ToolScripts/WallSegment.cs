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
    int _MaxHealth;

    bool _isOnFire = false;
    bool _isFireSource = false;
    bool _spreadFlag = true;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        _MaxHealth = _health;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (_health >= _MaxHealth / 2 && _spreadFlag)
        {
            SpreadFire();
            _spreadFlag = false;
        }
    }

    /// <summary>
    /// Detects collisions with triggers
    /// </summary>
    /// <param name="other">object this collides with</param>
    private void OnTriggerEnter(Collider other)
    {
        // Lights on contact with fire
        if (gameObject.tag != "FireResistant" && !_isOnFire)
        {
            if (other.tag == "PlayerFire")
            {
                _isOnFire = true;
                StartCoroutine(BurnDown());
                _isFireSource = true;
            }
            if (other.tag == "SpreadFire")
            {
                _isOnFire = true;
                StartCoroutine(BurnDown());

            }
        }
    }

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

    /// <summary>
    /// Spreads fire to other objects
    /// </summary>
    void SpreadFire()
    {

    }

    /// <summary>
    /// Damages object over time
    /// </summary>
    /// <returns></returns>
    IEnumerator BurnDown()
    {
        while (_isOnFire)
        {
            LoseHealth(20);
            yield return new WaitForSeconds(.5f);
        }
    }
}
