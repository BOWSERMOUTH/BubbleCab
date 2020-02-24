// GENERATED AUTOMATICALLY FROM 'Assets/Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controller : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""9aa73afd-9e7f-46dd-ac7c-1f04f842ef3d"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""5a2c9b0d-4bd5-4a2f-8f37-92ae92aac959"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Backward"",
                    ""type"": ""Button"",
                    ""id"": ""2fa48e81-2335-4794-8246-0277a8f613cf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""2d4dc5bb-ddca-4e8d-8f3a-5bc29aa4f248"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""1e92c4f7-142c-4857-9a08-56078e2e4d04"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Radar"",
                    ""type"": ""Button"",
                    ""id"": ""7b7497df-8076-4084-b138-74b636ffd5a4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sonar"",
                    ""type"": ""Button"",
                    ""id"": ""46edbeb6-6380-4b0d-9045-e72695703a04"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Flashlight"",
                    ""type"": ""Button"",
                    ""id"": ""1d8338f0-b02e-42c6-8118-02a33fbd1320"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Claw"",
                    ""type"": ""Button"",
                    ""id"": ""03baf8b7-a4b1-4cfd-9bfa-d2a8c0ad2fda"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ClawGrab"",
                    ""type"": ""Button"",
                    ""id"": ""7f5962fc-7d05-43ad-93c8-9684dd36a0ea"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6fde516a-25e2-49c1-bbcc-9f31bc71763b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Hold(duration=0.01,pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64ac469b-fb74-4d57-acc6-5f68d04b5879"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Hold(duration=0.01,pressPoint=0.1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4b4c521-f21b-4cd0-be21-651f5a2c58c7"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0872b7f6-d93e-4c56-9ee2-3ffea15225f1"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f39dc3ca-302e-4151-aa9b-872264b9a3a3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Radar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c3e5708-1432-4bd1-b172-7e3d08ec89b7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sonar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""298bc9e1-6d16-4729-9699-f28fd26b5414"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flashlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""301674a3-473f-4342-90d3-1149d8c18905"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Claw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81ddce5c-605a-49ef-973e-555a2e252f19"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": ""Hold(duration=0.1,pressPoint=0.5)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClawGrab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Forward = m_Gameplay.FindAction("Forward", throwIfNotFound: true);
        m_Gameplay_Backward = m_Gameplay.FindAction("Backward", throwIfNotFound: true);
        m_Gameplay_Right = m_Gameplay.FindAction("Right", throwIfNotFound: true);
        m_Gameplay_Left = m_Gameplay.FindAction("Left", throwIfNotFound: true);
        m_Gameplay_Radar = m_Gameplay.FindAction("Radar", throwIfNotFound: true);
        m_Gameplay_Sonar = m_Gameplay.FindAction("Sonar", throwIfNotFound: true);
        m_Gameplay_Flashlight = m_Gameplay.FindAction("Flashlight", throwIfNotFound: true);
        m_Gameplay_Claw = m_Gameplay.FindAction("Claw", throwIfNotFound: true);
        m_Gameplay_ClawGrab = m_Gameplay.FindAction("ClawGrab", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Forward;
    private readonly InputAction m_Gameplay_Backward;
    private readonly InputAction m_Gameplay_Right;
    private readonly InputAction m_Gameplay_Left;
    private readonly InputAction m_Gameplay_Radar;
    private readonly InputAction m_Gameplay_Sonar;
    private readonly InputAction m_Gameplay_Flashlight;
    private readonly InputAction m_Gameplay_Claw;
    private readonly InputAction m_Gameplay_ClawGrab;
    public struct GameplayActions
    {
        private @Controller m_Wrapper;
        public GameplayActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Gameplay_Forward;
        public InputAction @Backward => m_Wrapper.m_Gameplay_Backward;
        public InputAction @Right => m_Wrapper.m_Gameplay_Right;
        public InputAction @Left => m_Wrapper.m_Gameplay_Left;
        public InputAction @Radar => m_Wrapper.m_Gameplay_Radar;
        public InputAction @Sonar => m_Wrapper.m_Gameplay_Sonar;
        public InputAction @Flashlight => m_Wrapper.m_Gameplay_Flashlight;
        public InputAction @Claw => m_Wrapper.m_Gameplay_Claw;
        public InputAction @ClawGrab => m_Wrapper.m_Gameplay_ClawGrab;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                @Backward.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBackward;
                @Backward.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBackward;
                @Backward.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBackward;
                @Right.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Radar.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRadar;
                @Radar.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRadar;
                @Radar.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRadar;
                @Sonar.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSonar;
                @Sonar.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSonar;
                @Sonar.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSonar;
                @Flashlight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFlashlight;
                @Flashlight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFlashlight;
                @Flashlight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFlashlight;
                @Claw.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClaw;
                @Claw.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClaw;
                @Claw.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClaw;
                @ClawGrab.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClawGrab;
                @ClawGrab.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClawGrab;
                @ClawGrab.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClawGrab;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Backward.started += instance.OnBackward;
                @Backward.performed += instance.OnBackward;
                @Backward.canceled += instance.OnBackward;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Radar.started += instance.OnRadar;
                @Radar.performed += instance.OnRadar;
                @Radar.canceled += instance.OnRadar;
                @Sonar.started += instance.OnSonar;
                @Sonar.performed += instance.OnSonar;
                @Sonar.canceled += instance.OnSonar;
                @Flashlight.started += instance.OnFlashlight;
                @Flashlight.performed += instance.OnFlashlight;
                @Flashlight.canceled += instance.OnFlashlight;
                @Claw.started += instance.OnClaw;
                @Claw.performed += instance.OnClaw;
                @Claw.canceled += instance.OnClaw;
                @ClawGrab.started += instance.OnClawGrab;
                @ClawGrab.performed += instance.OnClawGrab;
                @ClawGrab.canceled += instance.OnClawGrab;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRadar(InputAction.CallbackContext context);
        void OnSonar(InputAction.CallbackContext context);
        void OnFlashlight(InputAction.CallbackContext context);
        void OnClaw(InputAction.CallbackContext context);
        void OnClawGrab(InputAction.CallbackContext context);
    }
}
