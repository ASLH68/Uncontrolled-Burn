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
using UnityEngine;

public class FlameResistance : MonoBehaviour
{
    public static FlameResistance main;

    [SerializeField] private int _resistanceUses;
    //[SerializeField] private Material _resistantMaterial;
    [SerializeField] private TextMeshProUGUI _uiResistanceUses;
    [SerializeField] private List<WallSegment> _highlightedSegments;

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

    private void Start()
    {
        _uiResistanceUses = GameObject.Find("Resistance Count").GetComponent<TextMeshProUGUI>();
        _uiResistanceUses.text = _resistanceUses.ToString();
        _highlightedSegments = new List<WallSegment>();
    }

    private void Update()
    {
        // Use the flame resistance of applicable when they press LMB
        if (Input.GetMouseButtonDown(0))
        {
            FlameResistance.main.UseItem();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DisableAllHighlights();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_resistanceUses > 0)
        {
/*            if (_resistanceUses == _highlightedSegments.Count)
            {
                RemoveFromHighlight(_highlightedSegments[0].gameObject);
                //_highlightedSegments.RemoveAt(0);
            }*/
            if (_resistanceUses > _highlightedSegments.Count)
            {
                if (IsValidSegment(other.gameObject) && !_highlightedSegments.Contains(other.gameObject.GetComponent<WallSegment>()))
                {
                    WallSegment tempObj = other.GetComponent<WallSegment>();
                    _highlightedSegments.Add(tempObj);

                    SelectedFlash selectedFlash = tempObj.GetComponent<SelectedFlash>();
                    if (!selectedFlash.startedFlashing)
                    {
                        selectedFlash.SetStartFlashing(true);
                        selectedFlash.BeginFlashing();
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        RemoveFromHighlight(other.gameObject, false);
    }

    /// <summary>
    /// Removes the game object from the highlight system
    /// </summary>
    /// <param name="obj"></param>
    private void RemoveFromHighlight(GameObject obj, bool clearingAll)
    {
        if (IsValidSegment(obj) && _highlightedSegments.Contains(obj.GetComponent<WallSegment>()))
        {
            WallSegment tempObj = obj.GetComponent<WallSegment>();

            if (!clearingAll)
            {
                _highlightedSegments.Remove(obj.GetComponent<WallSegment>());
            }

            SelectedFlash selectedFlash = tempObj.GetComponent<SelectedFlash>();
            if (selectedFlash.startedFlashing)
            {
                selectedFlash.SetStartFlashing(false);
            }
        }
    }

    /// <summary>
    /// Makes all highlighted objects stop being highlighted
    /// </summary>
    public void DisableAllHighlights()
    {
        if (_highlightedSegments.Count > 0)
        {
            foreach (WallSegment wallSeg in _highlightedSegments)
            {
                RemoveFromHighlight(wallSeg.gameObject, true);
            }
            _highlightedSegments.Clear();
        }
    }

    /// <summary>
    /// Applies the reistant tag and reduces amount of item uses
    /// </summary>
    /// <param name="wallSeg"> wall segment being affected </param>
    public void UseItem()
    {
        if (_highlightedSegments.Count > 0)
        {
            foreach (WallSegment wallSeg in _highlightedSegments)
            {
                if (_resistanceUses > 0)
                {
                    // Ends the wall highlight flash
                    wallSeg.GetComponent<SelectedFlash>().SetStartFlashing(false);
                    wallSeg.Shrink();
                    wallSeg.GetComponent<WallSegment>().SetIsResistant();

                    //applies the tag and reduces usage by one, + player feedback
                    wallSeg.gameObject.tag = "FireResistant";
                    _resistanceUses--;
                    _uiResistanceUses.text = _resistanceUses.ToString();
                    wallSeg.gameObject.GetComponent<Renderer>().material = wallSeg.GetComponent<WallSegment>().LitMaterial;
                    wallSeg.gameObject.GetComponent<WallSegment>().OriginalColor = Color.white; // When hit by axe, wil remain blue
                }               
            }
            _highlightedSegments.Clear();
        }
        else
        {
            Debug.Log("Out of resistant");
        }
    }

    /// <summary>
    /// Determines if a wall segment can have resistance applied to it
    /// </summary>
    /// <returns></returns>
    private bool IsValidSegment(GameObject obj)
    {
        return obj.CompareTag("WallSegment") &&
               !obj.CompareTag("Indestructable") &&
               !obj.GetComponent<WallSegment>().IsOnFire &&
               !obj.CompareTag("FireResistant");
    }
}
