/*****************************************************************************
// File Name :         CastingToObject.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     April 4th, 2023
//
// Brief Description : This document controls raycasting objects.
                       References: https://www.youtube.com/watch?v=7ybz28Py0-U
                                   https://www.youtube.com/watch?v=cUf7FnNqv7U

*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class CastingToObject : MonoBehaviour
{
    //public static CastingToObject main;     // Instance

    public static string selectedObject;    // name of the casted object
    public string internalObject;   // explicility to visualize in the inspector
    private RaycastHit theObject;    // Gets whatever object is hit
    private GameObject _mainCamera;
    [SerializeField] LayerMask _layerMask;  // Layer to look for segments on
    private GameObject _castedObject;   // currently casted object

    private void Start()
    {
        _mainCamera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(_mainCamera.transform.position, transform.TransformDirection(Vector3.forward), out theObject, 10f, _layerMask))
        {
            // If raycast target changed, reset previous object
            if (_castedObject != null && !theObject.transform.gameObject.Equals(_castedObject))
            {
                ResetObject();
            }
            SelectObject();
            HighlightObject();
        }
        else 
        {
            // Resets current object when stopped hovering
            ResetObject();
        }
    }

    /// <summary>
    /// Sets the casted object to relevant variables
    /// </summary>
    private void SelectObject()
    {
        selectedObject = theObject.transform.gameObject.name;   // returns the name of the obj
        internalObject = theObject.transform.name;
        _castedObject = theObject.transform.gameObject;
    }

    /// <summary>
    /// Resets the casted object variables & highlight
    /// </summary>
    private void ResetObject()
    {
        selectedObject = "";
        internalObject = "";
        selectedObject = null;
        StopHighlight();
    }

    /// <summary>
    /// Begins the objects highlight indicator
    /// </summary>
    private void HighlightObject()
    {
        SelectedFlash selectedFlash = _castedObject.GetComponent<SelectedFlash>();
        selectedFlash.selectedObject = _castedObject;
        if (!selectedFlash.startedFlashing)
        {
            selectedFlash.SetStartFlashing(true);
            selectedFlash.BeginFlashing();
        }
    }

    /// <summary>
    /// Stops the objects flashing
    /// </summary>
    private void StopHighlight()
    {
        SelectedFlash selectedFlash = _castedObject.GetComponent<SelectedFlash>();
        if (selectedFlash.startedFlashing)
        {
            selectedFlash.SetStartFlashing(false);
        }

    }
}
