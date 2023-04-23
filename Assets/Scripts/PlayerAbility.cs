using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbility : MonoBehaviour
{
    public static PlayerAbility main;
    public PlayerControls actions;

    // Ability Variables
    [SerializeField] private int currentAbility = 0; // It's serialized so the player can start with X ability
    private int numOfAbilities = 3;

    public int CurrentAbility => currentAbility;

    private List<GameObject> highlights = new List<GameObject>();
    private List<GameObject> uiSlot = new List<GameObject>();

    // Objects to grab
    [SerializeField] private List<GameObject> playerItems = new List<GameObject>();

    // This initializes the player controls
    void Awake()
    {
        actions = new PlayerControls();

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
        currentAbility = 0;
        highlights = new List<GameObject>(GameObject.FindGameObjectsWithTag("ItemSlot"));

        // This grabs all of the highlights and uislots
        foreach(GameObject highlight in highlights)
        {
            uiSlot.Add(highlight.transform.parent.gameObject);

            highlight.SetActive(false);
        }

        // This grabs all of the tools
        playerItems = new List<GameObject>(GameObject.FindGameObjectsWithTag("Tool"));

        // Ah, ha ha. This made it out of order, so this next part will put it in order
        #region FixToolOrder
        GameObject temp = playerItems[0];
        playerItems[0] = playerItems[2];
        playerItems[2] = temp;
        #endregion

        foreach (GameObject tool in playerItems)
        {
            tool.SetActive(false);
        }

        playerItems[currentAbility].SetActive(true);
        highlights[currentAbility].SetActive(true);

        uiSlot[currentAbility].transform.localScale *= 1.25f;
    }

    /// <summary>
    /// This function will disbale the previous item, swap the number for the currently used item, 
    /// and enable the currently used item
    /// Through a button functionality
    /// </summary>
    private void AbilitySwap(int swap)
    {
        if (!PauseMenu.main.IsPaused && currentAbility != swap)
        {
            playerItems[currentAbility].SetActive(false);
            highlights[currentAbility].SetActive(false);
            uiSlot[currentAbility].transform.localScale /= 1.25f;


            if (currentAbility == 2 && swap != 2)
            {
                AxeController.main.ResetAxeState();     // Allows axe to be used again if switched off mid attack
            }
            if(currentAbility == 1 && swap != 1)
            {
                FlameResistance.main.DisableAllHighlights();    // Removes currently highlighted trees from selection
            }

            currentAbility = swap;

            // Begins the resistent selection
            if (currentAbility == 1)
            {
                PlayerController.main.SelectResistance = true;
            }
            else
            {
                PlayerController.main.SelectResistance = false;
            }

            playerItems[currentAbility].SetActive(true);
            highlights[currentAbility].SetActive(true);
            uiSlot[currentAbility].transform.localScale *= 1.25f;
        }
    }

    /// <summary>
    /// This function will disbale the previous item, swap the number for the currently used item, 
    /// and enable the currently used item
    /// Through a scroll wheel functionality
    /// </summary>
    private void SecondAbilitySwap(int swap)
    {
        if (!PauseMenu.main.IsPaused/* && currentAbility != swap*/) // Don't uncomment that part of the conditional!
        {
            playerItems[currentAbility].SetActive(false);
            highlights[currentAbility].SetActive(false);
            uiSlot[currentAbility].transform.localScale /= 1.25f;

            if (currentAbility == 2 && swap != 2)
            {
                AxeController.main.ResetAxeState();     // Allows axe to be used again if switched off mid attack
            }
            if (currentAbility == 1 && swap != 1)
            {
                FlameResistance.main.DisableAllHighlights();    // Removes currently highlighted trees from selection
            }

            currentAbility += swap;

            // Begins the resistent selection
            if(currentAbility == 1)
            {
                PlayerController.main.SelectResistance = true;
            }
            else
            {
                PlayerController.main.SelectResistance = false;
            }

            if (currentAbility >= numOfAbilities)
            {
                currentAbility = 0;
            }
            else if (currentAbility < 0)
            {
                currentAbility = numOfAbilities - 1;
            }
            playerItems[currentAbility].SetActive(true);
            highlights[currentAbility].SetActive(true);
            uiSlot[currentAbility].transform.localScale *= 1.25f;
        }
    }

    /// <summary>
    /// This is where the events get put in for what happens when you click a button
    /// </summary>
    private void OnEnable()
    {
        actions.Enable();

        // This is the item swapping section
        actions.Player.Item1.performed += ctx => AbilitySwap(0);
        actions.Player.Item2.performed += ctx => AbilitySwap(1);
        actions.Player.Item3.performed += ctx => AbilitySwap(2);

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
