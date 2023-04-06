/*****************************************************************************
// File Name :         FireResistance.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 6th, 2023
//
// Brief Description : This document controls the Fire Resistance Item.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class FlameResistance : MonoBehaviour
{
    public static FlameResistance main;

    private int _resistanceUses;

    public int ResistanceUses => _resistanceUses;

    public void Awake()
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

    /// <summary>
    /// Applies the reistant tag and reduces amount of item uses
    /// </summary>
    /// <param name="wallSeg"></param>
    public void UseItem(GameObject wallSeg)
    {
        wallSeg.gameObject.tag = "FireResistant";
        _resistanceUses--;
    }
}
