// GENERATED AUTOMATICALLY FROM 'Assets/SonarSpaceship/InputActions/GameInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace SonarSpaceship.InputActions
{
    public class @GameInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputActions"",
    ""maps"": [
        {
            ""name"": ""GameActionMap"",
            ""id"": ""ebfe994d-972c-4a8f-b6ff-7f96adc63349"",
            ""actions"": [
                {
                    ""name"": ""DetachContainer"",
                    ""type"": ""Button"",
                    ""id"": ""1758ec6d-d26a-44e2-8bba-ae0055c407dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookAt"",
                    ""type"": ""Value"",
                    ""id"": ""80b5597a-2d5a-40bd-918e-8983efd9e447"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""88823946-7210-4b6a-a008-62958aafeb0e"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ping"",
                    ""type"": ""Button"",
                    ""id"": ""27234c13-39d2-4b9c-8a42-c5e459a84e46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchMove"",
                    ""type"": ""Value"",
                    ""id"": ""b19526bc-1620-491c-9172-fa308edcd6b8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScreenLookAt"",
                    ""type"": ""Value"",
                    ""id"": ""42f39adc-6dca-400f-9f81-c6acfde0e988"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPressRelease"",
                    ""type"": ""PassThrough"",
                    ""id"": ""08f307fd-1bc9-4690-ae52-6e2c36705a3e"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3802086e-0347-47f9-b69d-ea1d5f10ff8b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASDKeys"",
                    ""id"": ""83c12ed9-b928-4c2b-9c77-aad32a90e677"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""493cbb0f-8121-4ba8-9f04-ead7db86ec4c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b436148c-d22e-4ab0-8e9b-90280f071fd8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d147380c-9cd3-421d-b5a4-1bbd709b66e5"",
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
                    ""id"": ""58f6bdb3-bba8-4ee8-949e-1de5e88f09d3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""77f6582f-3253-41d9-bfae-39bb653d045d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ad22579f-0e62-424f-8e79-7348c5b806cf"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""021b1003-897d-422e-8cae-4ac7f78a1d47"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5f634632-616e-4c99-ad1f-5d78f18cd5a3"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9f0b93ba-01dc-462b-ab68-f9eab6e761fa"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""81c31810-2d68-48e4-9e14-c5a82c5489d7"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ping"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67be98ef-4da9-4153-bbb8-74f842c683d0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ping"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f6ff096-5b99-424c-b5ea-de758b007da4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DetachContainer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31f01c72-0f17-431d-a0e0-f9999c2cdf41"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DetachContainer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d01dc6cf-83b8-49bc-ac5b-cbb1227a551a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69d0079a-8434-4183-b4ab-6eaa89e6c3fa"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScreenLookAt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14edf080-84da-4d57-b5cc-4a612e27382d"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScreenLookAt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e35cea43-7ca9-4e3c-b58b-eba3cf3ee9f6"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""373911e3-29ef-42a3-9a1e-75356a2799d0"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPressRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // GameActionMap
            m_GameActionMap = asset.FindActionMap("GameActionMap", throwIfNotFound: true);
            m_GameActionMap_DetachContainer = m_GameActionMap.FindAction("DetachContainer", throwIfNotFound: true);
            m_GameActionMap_LookAt = m_GameActionMap.FindAction("LookAt", throwIfNotFound: true);
            m_GameActionMap_Move = m_GameActionMap.FindAction("Move", throwIfNotFound: true);
            m_GameActionMap_Ping = m_GameActionMap.FindAction("Ping", throwIfNotFound: true);
            m_GameActionMap_TouchMove = m_GameActionMap.FindAction("TouchMove", throwIfNotFound: true);
            m_GameActionMap_ScreenLookAt = m_GameActionMap.FindAction("ScreenLookAt", throwIfNotFound: true);
            m_GameActionMap_TouchPressRelease = m_GameActionMap.FindAction("TouchPressRelease", throwIfNotFound: true);
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

        // GameActionMap
        private readonly InputActionMap m_GameActionMap;
        private IGameActionMapActions m_GameActionMapActionsCallbackInterface;
        private readonly InputAction m_GameActionMap_DetachContainer;
        private readonly InputAction m_GameActionMap_LookAt;
        private readonly InputAction m_GameActionMap_Move;
        private readonly InputAction m_GameActionMap_Ping;
        private readonly InputAction m_GameActionMap_TouchMove;
        private readonly InputAction m_GameActionMap_ScreenLookAt;
        private readonly InputAction m_GameActionMap_TouchPressRelease;
        public struct GameActionMapActions
        {
            private @GameInputActions m_Wrapper;
            public GameActionMapActions(@GameInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @DetachContainer => m_Wrapper.m_GameActionMap_DetachContainer;
            public InputAction @LookAt => m_Wrapper.m_GameActionMap_LookAt;
            public InputAction @Move => m_Wrapper.m_GameActionMap_Move;
            public InputAction @Ping => m_Wrapper.m_GameActionMap_Ping;
            public InputAction @TouchMove => m_Wrapper.m_GameActionMap_TouchMove;
            public InputAction @ScreenLookAt => m_Wrapper.m_GameActionMap_ScreenLookAt;
            public InputAction @TouchPressRelease => m_Wrapper.m_GameActionMap_TouchPressRelease;
            public InputActionMap Get() { return m_Wrapper.m_GameActionMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActionMapActions set) { return set.Get(); }
            public void SetCallbacks(IGameActionMapActions instance)
            {
                if (m_Wrapper.m_GameActionMapActionsCallbackInterface != null)
                {
                    @DetachContainer.started -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnDetachContainer;
                    @DetachContainer.performed -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnDetachContainer;
                    @DetachContainer.canceled -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnDetachContainer;
                    @LookAt.started -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnLookAt;
                    @LookAt.performed -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnLookAt;
                    @LookAt.canceled -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnLookAt;
                    @Move.started -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnMove;
                    @Ping.started -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnPing;
                    @Ping.performed -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnPing;
                    @Ping.canceled -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnPing;
                    @TouchMove.started -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnTouchMove;
                    @TouchMove.performed -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnTouchMove;
                    @TouchMove.canceled -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnTouchMove;
                    @ScreenLookAt.started -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnScreenLookAt;
                    @ScreenLookAt.performed -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnScreenLookAt;
                    @ScreenLookAt.canceled -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnScreenLookAt;
                    @TouchPressRelease.started -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnTouchPressRelease;
                    @TouchPressRelease.performed -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnTouchPressRelease;
                    @TouchPressRelease.canceled -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnTouchPressRelease;
                }
                m_Wrapper.m_GameActionMapActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @DetachContainer.started += instance.OnDetachContainer;
                    @DetachContainer.performed += instance.OnDetachContainer;
                    @DetachContainer.canceled += instance.OnDetachContainer;
                    @LookAt.started += instance.OnLookAt;
                    @LookAt.performed += instance.OnLookAt;
                    @LookAt.canceled += instance.OnLookAt;
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Ping.started += instance.OnPing;
                    @Ping.performed += instance.OnPing;
                    @Ping.canceled += instance.OnPing;
                    @TouchMove.started += instance.OnTouchMove;
                    @TouchMove.performed += instance.OnTouchMove;
                    @TouchMove.canceled += instance.OnTouchMove;
                    @ScreenLookAt.started += instance.OnScreenLookAt;
                    @ScreenLookAt.performed += instance.OnScreenLookAt;
                    @ScreenLookAt.canceled += instance.OnScreenLookAt;
                    @TouchPressRelease.started += instance.OnTouchPressRelease;
                    @TouchPressRelease.performed += instance.OnTouchPressRelease;
                    @TouchPressRelease.canceled += instance.OnTouchPressRelease;
                }
            }
        }
        public GameActionMapActions @GameActionMap => new GameActionMapActions(this);
        public interface IGameActionMapActions
        {
            void OnDetachContainer(InputAction.CallbackContext context);
            void OnLookAt(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnPing(InputAction.CallbackContext context);
            void OnTouchMove(InputAction.CallbackContext context);
            void OnScreenLookAt(InputAction.CallbackContext context);
            void OnTouchPressRelease(InputAction.CallbackContext context);
        }
    }
}
