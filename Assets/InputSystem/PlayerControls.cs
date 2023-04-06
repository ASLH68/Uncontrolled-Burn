//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputSystem/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""04f668f2-464c-4995-b685-b02384915642"",
            ""actions"": [
                {
                    ""name"": ""Item1"",
                    ""type"": ""Button"",
                    ""id"": ""299e45d4-8847-4090-ae76-17c5c16f1010"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item2"",
                    ""type"": ""Button"",
                    ""id"": ""5fff040a-a0b4-47a9-9a7a-6e2326a9b10d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item3"",
                    ""type"": ""Button"",
                    ""id"": ""854a06fc-ab56-4af1-b4a3-72d848937b38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ItemScroll"",
                    ""type"": ""Value"",
                    ""id"": ""c45b6120-b89f-4179-b400-92b69c134505"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AbilityUse"",
                    ""type"": ""Button"",
                    ""id"": ""5ebc9171-5de7-45d4-82ef-1a63f0088001"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""df8f467a-d33e-4e59-8d88-46f1337031c6"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b65b3c17-fd28-4731-990f-62c9d721681e"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aac82763-058d-4027-bac7-29ae4259d9a6"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfd78b22-9f98-4899-bdf4-c059c4daaad5"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bded41bb-59c4-4216-8299-8431187b4a11"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe6e02ea-c1f1-4012-835c-d9ed7249695e"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38702318-ae90-47ff-ac2f-77b6a7742bc0"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ItemScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7377616b-9a10-4382-aca2-5edd2630e350"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityUse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Item1 = m_Player.FindAction("Item1", throwIfNotFound: true);
        m_Player_Item2 = m_Player.FindAction("Item2", throwIfNotFound: true);
        m_Player_Item3 = m_Player.FindAction("Item3", throwIfNotFound: true);
        m_Player_ItemScroll = m_Player.FindAction("ItemScroll", throwIfNotFound: true);
        m_Player_AbilityUse = m_Player.FindAction("AbilityUse", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Item1;
    private readonly InputAction m_Player_Item2;
    private readonly InputAction m_Player_Item3;
    private readonly InputAction m_Player_ItemScroll;
    private readonly InputAction m_Player_AbilityUse;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Item1 => m_Wrapper.m_Player_Item1;
        public InputAction @Item2 => m_Wrapper.m_Player_Item2;
        public InputAction @Item3 => m_Wrapper.m_Player_Item3;
        public InputAction @ItemScroll => m_Wrapper.m_Player_ItemScroll;
        public InputAction @AbilityUse => m_Wrapper.m_Player_AbilityUse;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Item1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem1;
                @Item1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem1;
                @Item1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem1;
                @Item2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem2;
                @Item2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem2;
                @Item2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem2;
                @Item3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem3;
                @Item3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem3;
                @Item3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem3;
                @ItemScroll.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemScroll;
                @ItemScroll.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemScroll;
                @ItemScroll.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemScroll;
                @AbilityUse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbilityUse;
                @AbilityUse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbilityUse;
                @AbilityUse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbilityUse;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Item1.started += instance.OnItem1;
                @Item1.performed += instance.OnItem1;
                @Item1.canceled += instance.OnItem1;
                @Item2.started += instance.OnItem2;
                @Item2.performed += instance.OnItem2;
                @Item2.canceled += instance.OnItem2;
                @Item3.started += instance.OnItem3;
                @Item3.performed += instance.OnItem3;
                @Item3.canceled += instance.OnItem3;
                @ItemScroll.started += instance.OnItemScroll;
                @ItemScroll.performed += instance.OnItemScroll;
                @ItemScroll.canceled += instance.OnItemScroll;
                @AbilityUse.started += instance.OnAbilityUse;
                @AbilityUse.performed += instance.OnAbilityUse;
                @AbilityUse.canceled += instance.OnAbilityUse;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnItem1(InputAction.CallbackContext context);
        void OnItem2(InputAction.CallbackContext context);
        void OnItem3(InputAction.CallbackContext context);
        void OnItemScroll(InputAction.CallbackContext context);
        void OnAbilityUse(InputAction.CallbackContext context);
    }
}
