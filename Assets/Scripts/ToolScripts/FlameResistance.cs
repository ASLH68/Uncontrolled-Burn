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

    [SerializeField] private int _resistanceUses;
    //[SerializeField] private Material _resistantMaterial;

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
    /// <param name="wallSeg"> wall segment being affected </param>
    public void UseItem(GameObject wallSeg)
    {
        if (_resistanceUses > 0)
        {
            // Ends the wall highlight flash
            wallSeg.GetComponent<SelectedFlash>().SetStartFlashing(false);
            wallSeg.GetComponent<WallSegment>().SetIsResistant();

            //applies the tag and reduces usage by one, + player feedback
            wallSeg.gameObject.tag = "FireResistant";   
            _resistanceUses--;
            wallSeg.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
        else
        {
            Debug.Log("Out of resistant");
        }
    }
}
