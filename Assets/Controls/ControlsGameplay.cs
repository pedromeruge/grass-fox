//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Controls/ControlsGameplay.inputactions
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

public partial class @ControlsGameplay: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlsGameplay()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlsGameplay"",
    ""maps"": [
        {
            ""name"": ""CharacterSelector"",
            ""id"": ""4b1377a9-1248-46ea-bd54-7ac1316946c7"",
            ""actions"": [
                {
                    ""name"": ""ChangeCharacter"",
                    ""type"": ""Value"",
                    ""id"": ""e01fb9dc-adc4-40f8-8a7c-50db1ba69ae3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Ready"",
                    ""type"": ""Button"",
                    ""id"": ""497c4ec2-7b37-4ccc-93ee-28baf83561a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""ec77d74e-5685-42f6-b510-4c09f0500cc1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Disconnect"",
                    ""type"": ""Button"",
                    ""id"": ""297cae75-b95d-4e3f-9b9d-3a38f007d4c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e2991dbb-946c-4e87-bc0d-93728646c56c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""2f8b7e7d-4584-456d-a4a6-cb0889024f1f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""debba8cd-5618-486a-a7d9-729434656391"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""70ed59ed-39ab-48a3-8197-415110dca7bc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""36669858-a45c-4dbb-b630-0bc42426147b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2a680a36-7aea-4076-a5d5-df1542c05424"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad D-Pad"",
                    ""id"": ""186238e6-341d-4131-9e1f-2445be8fda6f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""d7a452a1-bac5-494c-b21b-407789228efc"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""9f8acaf2-0441-4fc4-a026-7a72e1465f7b"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""435a12c3-4a28-4967-9494-cc3cf3609aa7"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""0d6a0a9e-4969-4f53-8823-e91c6b8c70f8"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""80a9181c-7b3f-47bc-9630-e594f11e767e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Disconnect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""540cbaa2-cc34-46e2-8bba-61532ad23d00"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Disconnect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2312d79-ac27-4a89-b303-eb91b2da8a37"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92d879e0-90ea-44dc-934c-81baecbad21c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d32eb902-f0fb-4299-9a54-c55191ce5720"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d49a75d-e4de-4048-bf78-133ef4e9cca8"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerMoveAttack"",
            ""id"": ""eb0c9a28-5184-4f7d-92ba-037f7fc66fe1"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""f2382da3-861a-4d8e-a53d-2bf817678beb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""fd12f026-4e86-45b8-b725-6ec4968bc92b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""c46fd722-cbf7-4169-9594-3dad3a29f956"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack1"",
                    ""type"": ""Button"",
                    ""id"": ""948edc46-5f87-4556-b34b-ab8c55c125da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack2"",
                    ""type"": ""Button"",
                    ""id"": ""687ce75d-24ca-47b9-b253-1c7dbf006427"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack3"",
                    ""type"": ""Button"",
                    ""id"": ""7cd32a5b-dba6-46c4-81d0-a28678d9b62e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack4"",
                    ""type"": ""Button"",
                    ""id"": ""297de245-1ca1-4d12-a5ce-97655b6fe00b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9548469c-8349-401c-acc5-57cde5f2bc59"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""190ec139-1e55-4aa8-9a80-c25c485da2e4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ab557454-f7fb-4693-965b-a63c10dccaa5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1079d455-8b2a-436b-b470-a53a63b3b6ea"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1613d399-c6b8-4e8a-825e-ffac9cdc0da0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b17cc10f-9a57-40f0-bf0c-aeba1884dea2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1065e8cc-7bcb-40a7-8278-082723ea1259"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3013692e-c84f-4ae4-8af1-03645ad2c187"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee64b790-4687-482d-a8ce-e53dba39f9f4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""101c3f83-1706-41e1-b64e-ca15a576bd30"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0eb0a82-cd43-40b0-b4bb-3a27b6bd5dde"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b27289c-f2ee-46bc-b1d7-999fefced578"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1fc6579-126a-4619-b8ba-d4190be6d4a8"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""866c73c4-0510-4094-a67f-8b962ea9b0df"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff3a6bd4-07b4-458c-8865-1c8af507d300"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""056455a4-b36d-4e48-9c07-59d5a8c07df4"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1adb72b9-4876-4ddc-a53f-207a8c30b794"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""908b0809-c83e-4d37-91de-7b39e8535d0f"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterSelector
        m_CharacterSelector = asset.FindActionMap("CharacterSelector", throwIfNotFound: true);
        m_CharacterSelector_ChangeCharacter = m_CharacterSelector.FindAction("ChangeCharacter", throwIfNotFound: true);
        m_CharacterSelector_Ready = m_CharacterSelector.FindAction("Ready", throwIfNotFound: true);
        m_CharacterSelector_Start = m_CharacterSelector.FindAction("Start", throwIfNotFound: true);
        m_CharacterSelector_Disconnect = m_CharacterSelector.FindAction("Disconnect", throwIfNotFound: true);
        // PlayerMoveAttack
        m_PlayerMoveAttack = asset.FindActionMap("PlayerMoveAttack", throwIfNotFound: true);
        m_PlayerMoveAttack_Move = m_PlayerMoveAttack.FindAction("Move", throwIfNotFound: true);
        m_PlayerMoveAttack_Jump = m_PlayerMoveAttack.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMoveAttack_Crouch = m_PlayerMoveAttack.FindAction("Crouch", throwIfNotFound: true);
        m_PlayerMoveAttack_Attack1 = m_PlayerMoveAttack.FindAction("Attack1", throwIfNotFound: true);
        m_PlayerMoveAttack_Attack2 = m_PlayerMoveAttack.FindAction("Attack2", throwIfNotFound: true);
        m_PlayerMoveAttack_Attack3 = m_PlayerMoveAttack.FindAction("Attack3", throwIfNotFound: true);
        m_PlayerMoveAttack_Attack4 = m_PlayerMoveAttack.FindAction("Attack4", throwIfNotFound: true);
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

    // CharacterSelector
    private readonly InputActionMap m_CharacterSelector;
    private List<ICharacterSelectorActions> m_CharacterSelectorActionsCallbackInterfaces = new List<ICharacterSelectorActions>();
    private readonly InputAction m_CharacterSelector_ChangeCharacter;
    private readonly InputAction m_CharacterSelector_Ready;
    private readonly InputAction m_CharacterSelector_Start;
    private readonly InputAction m_CharacterSelector_Disconnect;
    public struct CharacterSelectorActions
    {
        private @ControlsGameplay m_Wrapper;
        public CharacterSelectorActions(@ControlsGameplay wrapper) { m_Wrapper = wrapper; }
        public InputAction @ChangeCharacter => m_Wrapper.m_CharacterSelector_ChangeCharacter;
        public InputAction @Ready => m_Wrapper.m_CharacterSelector_Ready;
        public InputAction @Start => m_Wrapper.m_CharacterSelector_Start;
        public InputAction @Disconnect => m_Wrapper.m_CharacterSelector_Disconnect;
        public InputActionMap Get() { return m_Wrapper.m_CharacterSelector; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterSelectorActions set) { return set.Get(); }
        public void AddCallbacks(ICharacterSelectorActions instance)
        {
            if (instance == null || m_Wrapper.m_CharacterSelectorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharacterSelectorActionsCallbackInterfaces.Add(instance);
            @ChangeCharacter.started += instance.OnChangeCharacter;
            @ChangeCharacter.performed += instance.OnChangeCharacter;
            @ChangeCharacter.canceled += instance.OnChangeCharacter;
            @Ready.started += instance.OnReady;
            @Ready.performed += instance.OnReady;
            @Ready.canceled += instance.OnReady;
            @Start.started += instance.OnStart;
            @Start.performed += instance.OnStart;
            @Start.canceled += instance.OnStart;
            @Disconnect.started += instance.OnDisconnect;
            @Disconnect.performed += instance.OnDisconnect;
            @Disconnect.canceled += instance.OnDisconnect;
        }

        private void UnregisterCallbacks(ICharacterSelectorActions instance)
        {
            @ChangeCharacter.started -= instance.OnChangeCharacter;
            @ChangeCharacter.performed -= instance.OnChangeCharacter;
            @ChangeCharacter.canceled -= instance.OnChangeCharacter;
            @Ready.started -= instance.OnReady;
            @Ready.performed -= instance.OnReady;
            @Ready.canceled -= instance.OnReady;
            @Start.started -= instance.OnStart;
            @Start.performed -= instance.OnStart;
            @Start.canceled -= instance.OnStart;
            @Disconnect.started -= instance.OnDisconnect;
            @Disconnect.performed -= instance.OnDisconnect;
            @Disconnect.canceled -= instance.OnDisconnect;
        }

        public void RemoveCallbacks(ICharacterSelectorActions instance)
        {
            if (m_Wrapper.m_CharacterSelectorActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharacterSelectorActions instance)
        {
            foreach (var item in m_Wrapper.m_CharacterSelectorActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharacterSelectorActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharacterSelectorActions @CharacterSelector => new CharacterSelectorActions(this);

    // PlayerMoveAttack
    private readonly InputActionMap m_PlayerMoveAttack;
    private List<IPlayerMoveAttackActions> m_PlayerMoveAttackActionsCallbackInterfaces = new List<IPlayerMoveAttackActions>();
    private readonly InputAction m_PlayerMoveAttack_Move;
    private readonly InputAction m_PlayerMoveAttack_Jump;
    private readonly InputAction m_PlayerMoveAttack_Crouch;
    private readonly InputAction m_PlayerMoveAttack_Attack1;
    private readonly InputAction m_PlayerMoveAttack_Attack2;
    private readonly InputAction m_PlayerMoveAttack_Attack3;
    private readonly InputAction m_PlayerMoveAttack_Attack4;
    public struct PlayerMoveAttackActions
    {
        private @ControlsGameplay m_Wrapper;
        public PlayerMoveAttackActions(@ControlsGameplay wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMoveAttack_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerMoveAttack_Jump;
        public InputAction @Crouch => m_Wrapper.m_PlayerMoveAttack_Crouch;
        public InputAction @Attack1 => m_Wrapper.m_PlayerMoveAttack_Attack1;
        public InputAction @Attack2 => m_Wrapper.m_PlayerMoveAttack_Attack2;
        public InputAction @Attack3 => m_Wrapper.m_PlayerMoveAttack_Attack3;
        public InputAction @Attack4 => m_Wrapper.m_PlayerMoveAttack_Attack4;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMoveAttack; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMoveAttackActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerMoveAttackActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerMoveAttackActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerMoveAttackActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
            @Attack1.started += instance.OnAttack1;
            @Attack1.performed += instance.OnAttack1;
            @Attack1.canceled += instance.OnAttack1;
            @Attack2.started += instance.OnAttack2;
            @Attack2.performed += instance.OnAttack2;
            @Attack2.canceled += instance.OnAttack2;
            @Attack3.started += instance.OnAttack3;
            @Attack3.performed += instance.OnAttack3;
            @Attack3.canceled += instance.OnAttack3;
            @Attack4.started += instance.OnAttack4;
            @Attack4.performed += instance.OnAttack4;
            @Attack4.canceled += instance.OnAttack4;
        }

        private void UnregisterCallbacks(IPlayerMoveAttackActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
            @Attack1.started -= instance.OnAttack1;
            @Attack1.performed -= instance.OnAttack1;
            @Attack1.canceled -= instance.OnAttack1;
            @Attack2.started -= instance.OnAttack2;
            @Attack2.performed -= instance.OnAttack2;
            @Attack2.canceled -= instance.OnAttack2;
            @Attack3.started -= instance.OnAttack3;
            @Attack3.performed -= instance.OnAttack3;
            @Attack3.canceled -= instance.OnAttack3;
            @Attack4.started -= instance.OnAttack4;
            @Attack4.performed -= instance.OnAttack4;
            @Attack4.canceled -= instance.OnAttack4;
        }

        public void RemoveCallbacks(IPlayerMoveAttackActions instance)
        {
            if (m_Wrapper.m_PlayerMoveAttackActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerMoveAttackActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerMoveAttackActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerMoveAttackActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerMoveAttackActions @PlayerMoveAttack => new PlayerMoveAttackActions(this);
    public interface ICharacterSelectorActions
    {
        void OnChangeCharacter(InputAction.CallbackContext context);
        void OnReady(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnDisconnect(InputAction.CallbackContext context);
    }
    public interface IPlayerMoveAttackActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnAttack1(InputAction.CallbackContext context);
        void OnAttack2(InputAction.CallbackContext context);
        void OnAttack3(InputAction.CallbackContext context);
        void OnAttack4(InputAction.CallbackContext context);
    }
}
