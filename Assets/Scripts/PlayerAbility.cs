using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbility : MonoBehaviour
{
    PlayerActions actions;

    // Start is called before the first frame update
    void Start()
    {
        actions = new PlayerActions();
        actions.Enable();
    }

    private void AbilitySwap(int swap)
    {

    }

    private void OnEnable()
    {
        actions.Enable();

        actions.Player.Item1.performed += ctx => AbilitySwap(1);
        actions.Player.Item2.performed += ctx => AbilitySwap(2);
        actions.Player.Item3.performed += ctx => AbilitySwap(3);
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
