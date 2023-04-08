/*****************************************************************************
// File Name :         SelectFlash.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 5th, 2023
//
// Brief Description : This document controls the flashing of the wall segments.
                       References: https://www.youtube.com/watch?v=7ybz28Py0-U
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectedFlash : MonoBehaviour
{
    public GameObject selectedObject;   // the object being casted
    //public bool lookingAtObject = false;
    public bool flashingIn = true;      // start flashing as soon as looked at
    public bool startedFlashing = false;

    private Color _originalColor;

    public int redColor;
    public int greenColor;
    public int blueColor;

    private void Start()
    {
        selectedObject = gameObject;
        _originalColor = selectedObject.GetComponent<Renderer>().material.color;
    }
    // Update is called once per frame
    void Update()
    {
        if(startedFlashing)
        {
            selectedObject.GetComponent<Renderer>().material.color = new Color32((byte)redColor, (byte)greenColor, (byte)blueColor, 255);   
        }
    }

    /// <summary>
    /// Sets startedFlashing to val
    /// </summary>
    /// <param name="val">T/F</param>
    public void SetStartFlashing(bool val)
    {
        startedFlashing = val;
    }

    /// <summary>
    /// Begins the flashi
    /// </summary>
    public void BeginFlashing()
    {
        StartCoroutine(FlashObject());
    }
    
    /// <summary>
    /// Flashes the wall object
    /// </summary>
    /// <returns></returns>
    public IEnumerator FlashObject()
    {
        while (startedFlashing)
        {
            yield return new WaitForSeconds(0.05f);
            if (flashingIn)
            {
                // if blue color is gone, flashing is false
                if (blueColor <= 30)
                {
                    flashingIn = false;
                }
                else
                {
                    ModifyColors(-25);
                }
            }

            if (!flashingIn)
            {
                if (blueColor >= 250)
                {
                    flashingIn = true;
                }
                else
                {
                    ModifyColors(25);
                }
            }
        }
        // Resets objects color
        if(!selectedObject.GetComponent<WallSegment>().IsResistant)
        {
            selectedObject.GetComponent<Renderer>().material.color = _originalColor;
        }   
    }

    /// <summary>
    /// Modifies the colors used for the material
    /// </summary>
    /// <param name="amount"> amount each color is modified by </param>
    private void ModifyColors(int amount)
    {
        blueColor += amount;
        greenColor += amount;
        redColor += amount;
    }
}
