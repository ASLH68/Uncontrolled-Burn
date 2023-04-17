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
    private bool _isResistant = false;  // If wall is resistant to fire
    int _MaxHealth;

    public bool IsResistant => _isResistant;

    [SerializeField] private bool _isOnFire = false;
    private bool _isFireSource = false;
    private bool _spreadFlag = true;
    bool _burningTwice = false;

    public bool IsOnFire => _isOnFire;

    public Color OriginalColor;
    AudioSource _audioSource;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        _MaxHealth = _health;
        OriginalColor = gameObject.GetComponent<Renderer>().material.color;
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (_health <= _MaxHealth / 2 && _spreadFlag && _isOnFire)
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
        if (gameObject.tag != "FireResistant" && !_isOnFire
            && !GetComponent<Collider>().isTrigger)
        {
            if (other.tag == "PlayerFire")
            {
                _isOnFire = true;
                StartCoroutine(BurnDown());
                _isFireSource = true;
            }
        }

        if (_isOnFire)
        {
            _burningTwice = true;
            StartCoroutine(SecondBurn());
        }
    }

    /// <summary>
    /// Called when collision ends with trigger
    /// </summary>
    /// <param name="other">object that exits collision</param>
    private void OnTriggerExit(Collider other)
    {
        _burningTwice = false;
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
    /// ONLY FOR THE AXE ATTACK
    /// </summary>
    /// <param name="healthLost"></param>
    /// <param name="isAxe"></param>
    public void LoseHealth(int healthLost, bool isAxe)
    {
        LoseHealth(healthLost);
        StartCoroutine(FlashRed());
    }

    /// <summary>
    /// Sets _isResistant to true
    /// </summary>
    public void SetIsResistant()
    {
        _isResistant = true;
    }

    /// <summary>
    /// Destroys the wall segment
    /// </summary>
    private void DestroySegment()
    {
        if(IsOnFire)
        {
            GameController.main.DestroyTree(true);
        }
        else
        {
            GameController.main.DestroyTree(false);
        }
        
        Destroy(gameObject);
    }

    /// <summary>
    /// Spreads fire to other objects
    /// </summary>
    void SpreadFire()
    {
        //Debug.Log("spread");
        // Objects to attempt to ignite
        Collider[] spreadColliders = Physics.OverlapBox(transform.position,
            transform.lossyScale * 2);

        foreach (Collider i in spreadColliders)
        {
            //Debug.Log("object Detected");
            // Determines which objects to ignite
            if (i.gameObject.GetComponent<WallSegment>()
                && !i.gameObject.GetComponent<WallSegment>()._isOnFire
                && i.gameObject.tag != "FireResistant")
            {
                //Debug.Log("object flammable");
                WallSegment spreadWall =
                    i.gameObject.GetComponent<WallSegment>();

                // Performs ignition
                if (_isFireSource)
                {
                    spreadWall._isOnFire = true;
                    spreadWall.StartCoroutine(spreadWall.BurnDown());
                }
                else if (Random.Range(0, 2) == 1)
                {
                    spreadWall._isOnFire = true;
                    spreadWall.StartCoroutine(spreadWall.BurnDown());
                }
            }
        }
    }

    /// <summary>
    /// Flashes the game object red
    /// </summary>
    /// <returns></returns>
    private IEnumerator FlashRed()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color32((byte)100f, (byte)0f, (byte)0f, (byte)255);

        yield return new WaitForSeconds(1f);

        gameObject.GetComponent<Renderer>().material.color = OriginalColor;
    }

    /// <summary>
    /// Damages object over time
    /// </summary>
    /// <returns></returns>
    IEnumerator BurnDown()
    {
        GetComponent<Renderer>().material.color = Color.red;
        _audioSource.Play();

        while (_isOnFire)
        {
            LoseHealth(20);
            yield return new WaitForSeconds(.5f);
        }
    }
   
    /// <summary>
    /// Deals additional damage while fire is on
    /// </summary>
    /// <returns></returns>
    IEnumerator SecondBurn()
    {
        while (_burningTwice)
        {
            LoseHealth(20);
            yield return new WaitForSeconds(.5f);
        }
    }

}
