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

public class Flamethrower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Controls generation of fire object
    /// </summary>
    /// <param name="FireCone">object that determines fires position</param>
    public void CastFire(GameObject FireCone)
    {
        if (FireCone.activeInHierarchy)
        {
            FireCone.SetActive(false);
        }
        else
        {
            FireCone.SetActive(true);
        }
    }
}
