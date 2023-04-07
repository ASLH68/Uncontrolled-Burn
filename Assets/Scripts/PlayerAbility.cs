using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbility : MonoBehaviour
{
    public static PlayerAbility main;
    PlayerControls actions;

    // Ability Variables
    [SerializeField] private int currentAbility = 0; // It's serialized so the player can start with X ability
    private int numOfAbilities = 3;

    public int CurrentAbility => currentAbility;
    //private GameObject usedItem;

    //[SerializeField] private GameObject flamethrower;   
    //[SerializeField] private GameObject ax;
    //[SerializeField] private GameObject foam;

    // Objects to grab
    [SerializeField] private List<GameObject> playerItems = new List<GameObject>();
    [SerializeField] GameObject _fireCone;

    // I'm not sure if I'll use this...
    //[SerializeField] private enum items : int { FlameThrower, Ax, Foam };

    // This initializes the player controls
    void Awake()
    {
        actions = new PlayerControls();
        //actions.Enable();

        if (main == null)
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
        //usedItem = playerItems[currentAbility];
        playerItems[currentAbility].SetActive(true); // You will get errors unless you put objects in the list
    }

    /// <summary>
    /// This function will disbale the previous item, swap the number for the currently used item, 
    /// and enable the currently used item
    /// Through a button functionality
    /// </summary>
    private void AbilitySwap(int swap)
    {
        playerItems[currentAbility].SetActive(false); 
        currentAbility = swap - 1;
        playerItems[currentAbility].SetActive(true);
    }

    /// <summary>
    /// This function will disbale the previous item, swap the number for the currently used item, 
    /// and enable the currently used item
    /// Through a scroll wheel functionality
    /// </summary>
    private void SecondAbilitySwap(int swap)
    {
        playerItems[currentAbility].SetActive(false);

        currentAbility += swap - 1;

        if(currentAbility >= numOfAbilities)
        {
            currentAbility = 0;
        }
        else if(currentAbility < 0)
        {
            currentAbility = numOfAbilities - 1;
        }
        playerItems[currentAbility].SetActive(true);
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
                PlayerController.main.SelectResistence = true;
                break;
            case 2:

                break;
        }
    }

    /// <summary>
    /// This is where the events get put in for what happens when you click a button
    /// </summary>
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

    /// <summary>
    /// Makes sure the actions get disabled so you can't do them once the object no longer exists
    /// </summary>
    private void OnDisable()
    {
        actions.Disable();
    }
}
