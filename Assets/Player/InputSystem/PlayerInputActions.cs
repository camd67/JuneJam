//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Player/InputSystem/PlayerInputActions.inputactions
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

namespace Player.InputSystem
{
    public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player Actions"",
            ""id"": ""29ecffea-ab9b-4ea2-bdfa-43c70f3f54b1"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""06091ac4-2f28-4a45-b298-929d8f5c558a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""05e30e8c-fa07-46b5-8b2d-b84000286433"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1db7376b-dbf7-4424-be57-90745ab53190"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Global Actions"",
            ""id"": ""74f9ff60-20b5-4922-9767-2da680bedd57"",
            ""actions"": [
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""9dff5dae-227e-486e-bdd2-48e1a42c2b25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""675e6138-d608-470c-a8f6-6366e9a8878e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e963ba03-f88f-48d5-a735-be6da4badf6d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""502e8cbb-f7e8-495c-8897-d563d91f1b85"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player Actions
            m_PlayerActions = asset.FindActionMap("Player Actions", throwIfNotFound: true);
            m_PlayerActions_Fire = m_PlayerActions.FindAction("Fire", throwIfNotFound: true);
            // Global Actions
            m_GlobalActions = asset.FindActionMap("Global Actions", throwIfNotFound: true);
            m_GlobalActions_Restart = m_GlobalActions.FindAction("Restart", throwIfNotFound: true);
            m_GlobalActions_Quit = m_GlobalActions.FindAction("Quit", throwIfNotFound: true);
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

        // Player Actions
        private readonly InputActionMap m_PlayerActions;
        private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
        private readonly InputAction m_PlayerActions_Fire;
        public struct PlayerActionsActions
        {
            private @PlayerInputActions m_Wrapper;
            public PlayerActionsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Fire => m_Wrapper.m_PlayerActions_Fire;
            public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActionsActions instance)
            {
                if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
                {
                    @Fire.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnFire;
                    @Fire.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnFire;
                    @Fire.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnFire;
                }
                m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                }
            }
        }
        public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

        // Global Actions
        private readonly InputActionMap m_GlobalActions;
        private IGlobalActionsActions m_GlobalActionsActionsCallbackInterface;
        private readonly InputAction m_GlobalActions_Restart;
        private readonly InputAction m_GlobalActions_Quit;
        public struct GlobalActionsActions
        {
            private @PlayerInputActions m_Wrapper;
            public GlobalActionsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Restart => m_Wrapper.m_GlobalActions_Restart;
            public InputAction @Quit => m_Wrapper.m_GlobalActions_Quit;
            public InputActionMap Get() { return m_Wrapper.m_GlobalActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GlobalActionsActions set) { return set.Get(); }
            public void SetCallbacks(IGlobalActionsActions instance)
            {
                if (m_Wrapper.m_GlobalActionsActionsCallbackInterface != null)
                {
                    @Restart.started -= m_Wrapper.m_GlobalActionsActionsCallbackInterface.OnRestart;
                    @Restart.performed -= m_Wrapper.m_GlobalActionsActionsCallbackInterface.OnRestart;
                    @Restart.canceled -= m_Wrapper.m_GlobalActionsActionsCallbackInterface.OnRestart;
                    @Quit.started -= m_Wrapper.m_GlobalActionsActionsCallbackInterface.OnQuit;
                    @Quit.performed -= m_Wrapper.m_GlobalActionsActionsCallbackInterface.OnQuit;
                    @Quit.canceled -= m_Wrapper.m_GlobalActionsActionsCallbackInterface.OnQuit;
                }
                m_Wrapper.m_GlobalActionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Restart.started += instance.OnRestart;
                    @Restart.performed += instance.OnRestart;
                    @Restart.canceled += instance.OnRestart;
                    @Quit.started += instance.OnQuit;
                    @Quit.performed += instance.OnQuit;
                    @Quit.canceled += instance.OnQuit;
                }
            }
        }
        public GlobalActionsActions @GlobalActions => new GlobalActionsActions(this);
        public interface IPlayerActionsActions
        {
            void OnFire(InputAction.CallbackContext context);
        }
        public interface IGlobalActionsActions
        {
            void OnRestart(InputAction.CallbackContext context);
            void OnQuit(InputAction.CallbackContext context);
        }
    }
}
