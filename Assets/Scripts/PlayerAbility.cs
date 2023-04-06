using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbility : MonoBehaviour
{
    PlayerControls actions;

    [SerializeField] private int currentAbility = 0;
    private int numOfAbilities = 3;

    // Start is called before the first frame update
    void Awake()
    {
        actions = new PlayerControls();
        //actions.Enable();
    }

    private void AbilitySwap(int swap)
    {
        currentAbility = swap;
    }

    private void SecondAbilitySwap(int swap)
    {
        currentAbility += swap;

        if(currentAbility >= numOfAbilities)
        {
            currentAbility = 0;
        }
        else if(currentAbility < 0)
        {
            currentAbility = numOfAbilities - 1;
        }
        Debug.Log(currentAbility);
    }

    /// <summary>
    /// This happens when the player uses the [Right Mouse Button]
    /// It will switch case through the different abilities and select the right one ;)
    /// </summary>
    private void AbilityUse()
    {
        switch(currentAbility)
        {
            case 0:

                break;
                case 1:
                    
                break;
            case 2:

                break;
        }
    }

    private void OnEnable()
    {
        actions.Enable();

        // This is the item using section
        actions.Player.AbilityUse.performed += ctx => AbilityUse();

        // This would be used for stopping a hold down? 
        // I could probably make a different one for holding something down within the controls
        actions.Player.AbilityUse.canceled += ctx => AbilityUse();

        // This is the item swapping section
        actions.Player.Item1.performed += ctx => AbilitySwap(1);
        actions.Player.Item2.performed += ctx => AbilitySwap(2);
        actions.Player.Item3.performed += ctx => AbilitySwap(3);

        actions.Player.ItemScroll.performed += ctx => SecondAbilitySwap((int)ctx.ReadValue<float>() / Mathf.Abs((int)ctx.ReadValue<float>()));
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
