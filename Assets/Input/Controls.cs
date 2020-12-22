// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""6c7eb383-cc8c-4e25-b342-6e86e89a206d"",
            ""actions"": [
                {
                    ""name"": ""SwitchCameraView"",
                    ""type"": ""Button"",
                    ""id"": ""865c922d-693c-4a7b-a7bb-ba4dadcf0500"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fe6de27a-8d0a-4e3b-943c-3d8aafd0727f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCameraView"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Walker"",
            ""id"": ""7ed57fff-a5f4-49d4-960d-cab0a29a4384"",
            ""actions"": [
                {
                    ""name"": ""Speed"",
                    ""type"": ""Value"",
                    ""id"": ""46049948-d744-40a1-9c5b-ff29780d4ad0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""7daf3174-0bdf-41db-a3c1-70482aaf6237"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""352ce833-8f89-40f2-ad0f-a0d84f54b8f8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""40ff3b05-c9b2-4d3a-b45e-9aaa0c2bbe44"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0170587f-2704-4562-8fec-0c5544954040"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""205f3262-967b-42cc-9ea5-330afda9dc9d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""7d10b720-8908-445b-8c86-502d6f76c813"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""814ecb12-2d57-423a-b411-f9d8c8ee74dd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4640673f-fb25-452b-bb9f-186078c02cbc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e057faca-31c5-4d88-beee-091b59c69876"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2866b278-42b1-4c23-a529-228bdb458542"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_SwitchCameraView = m_Camera.FindAction("SwitchCameraView", throwIfNotFound: true);
        // Walker
        m_Walker = asset.FindActionMap("Walker", throwIfNotFound: true);
        m_Walker_Speed = m_Walker.FindAction("Speed", throwIfNotFound: true);
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

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_SwitchCameraView;
    public struct CameraActions
    {
        private @Controls m_Wrapper;
        public CameraActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @SwitchCameraView => m_Wrapper.m_Camera_SwitchCameraView;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @SwitchCameraView.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnSwitchCameraView;
                @SwitchCameraView.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnSwitchCameraView;
                @SwitchCameraView.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnSwitchCameraView;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SwitchCameraView.started += instance.OnSwitchCameraView;
                @SwitchCameraView.performed += instance.OnSwitchCameraView;
                @SwitchCameraView.canceled += instance.OnSwitchCameraView;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);

    // Walker
    private readonly InputActionMap m_Walker;
    private IWalkerActions m_WalkerActionsCallbackInterface;
    private readonly InputAction m_Walker_Speed;
    public struct WalkerActions
    {
        private @Controls m_Wrapper;
        public WalkerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Speed => m_Wrapper.m_Walker_Speed;
        public InputActionMap Get() { return m_Wrapper.m_Walker; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WalkerActions set) { return set.Get(); }
        public void SetCallbacks(IWalkerActions instance)
        {
            if (m_Wrapper.m_WalkerActionsCallbackInterface != null)
            {
                @Speed.started -= m_Wrapper.m_WalkerActionsCallbackInterface.OnSpeed;
                @Speed.performed -= m_Wrapper.m_WalkerActionsCallbackInterface.OnSpeed;
                @Speed.canceled -= m_Wrapper.m_WalkerActionsCallbackInterface.OnSpeed;
            }
            m_Wrapper.m_WalkerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Speed.started += instance.OnSpeed;
                @Speed.performed += instance.OnSpeed;
                @Speed.canceled += instance.OnSpeed;
            }
        }
    }
    public WalkerActions @Walker => new WalkerActions(this);
    public interface ICameraActions
    {
        void OnSwitchCameraView(InputAction.CallbackContext context);
    }
    public interface IWalkerActions
    {
        void OnSpeed(InputAction.CallbackContext context);
    }
}
