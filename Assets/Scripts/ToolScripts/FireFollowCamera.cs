/*****************************************************************************
// File Name :         FireFollowCamerar.cs
// Author :            Peter Campbell
// Creation Date :     April 7th, 2023
//
// Brief Description : Makes the fire's y rotation equal to the camera's
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFollowCamera : MonoBehaviour
{
    // Vars
    [SerializeField] GameObject _camera;
    Transform _cameraTransform;
    Vector3 _camRot;

    /// <summary>
    /// Called when scene boots
    /// </summary>
    private void Awake()
    {
        _cameraTransform = _camera.transform;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Finds camera's rotation and sets objects rotation to the same
        _camRot = _cameraTransform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(_camRot.x, _camRot.y,
            transform.rotation.z);
    }
}
