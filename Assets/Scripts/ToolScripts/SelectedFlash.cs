using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedFlash : MonoBehaviour
{
    public GameObject selectedObject;   // the object being casted
    public bool lookingAtObject = false;
    public bool flashingIn = true;      // start flashing as soon as looked at
    public bool startedFlashing = false;

    public int redColor;
    public int greenColor;
    public int blueColor;

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

/*    private void OnMouseOver()
    {
        selectedObject = GameObject.Find(CastingToObject.selectedObject);
        lookingAtObject = true;
        if(!startedFlashing)
        {
            startedFlashing = true;
            StartCoroutine(FlashObject());
        }
    }

    private void OnMouseExit()
    {
        startedFlashing = false;
        lookingAtObject = false;

        StopCoroutine(FlashObject());
        selectedObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
    }*/
    
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
                    blueColor -= 25;
                    greenColor -= 1;
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
                    blueColor += 25;
                    greenColor += 1;
                }
            }
        }
        // Resets objects color
        selectedObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
    }
}
