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
            ""name"": ""MemoryGame"",
            ""id"": ""89928d0b-ea22-474c-876c-341df6048b10"",
            ""actions"": [
                {
                    ""name"": ""TouchInput"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9a9e6a2a-ab46-48a2-804e-b0d92a581855"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""PassThrough"",
                    ""id"": ""25c7e7a7-f8d2-4dfe-9f25-83c22a9aee73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""32960804-675e-4711-be50-52e16b5ee7ee"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchDrag"",
                    ""type"": ""PassThrough"",
                    ""id"": ""69e1eec3-ac8c-4064-b861-0f94af048337"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d9d4ca5a-ca57-4482-90ea-4feb0f04d1ba"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2aa34418-185a-4785-97b5-bd32b5c97411"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35c0f152-f3fa-4a4c-8d43-40349f16c729"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09727306-20e9-434d-97a1-4342f6c8f55e"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f405058-8a35-4dd2-8b8c-42be674a39f1"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""id"": ""cf1908f3-3ad8-4172-ab60-d3867308fcd6"",
            ""actions"": [
                {
                    ""name"": ""Pointer"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3aeb809a-7b15-4f39-bf9a-39ed66746865"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Touch"",
                    ""id"": ""7241bc1e-00ae-468a-a406-d43b166c8498"",
                    ""path"": ""PointerInput"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""contact"",
                    ""id"": ""a9c53c99-8e3c-449e-95ce-0f01ecb7a76c"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""position"",
                    ""id"": ""f2e31ca6-156e-4d56-ad8b-e41b20b257dc"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""radius"",
                    ""id"": ""75bc2a48-8184-422b-8297-d2903d17255c"",
                    ""path"": ""<Touchscreen>/primaryTouch/radius"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""delta"",
                    ""id"": ""8659664e-88db-48d5-9d20-74a8fe41a620"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""pressure"",
                    ""id"": ""b35df4c2-0639-4a59-b06d-4bbef2f8a208"",
                    ""path"": ""<Touchscreen>/primaryTouch/pressure"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""inputId"",
                    ""id"": ""54f1237d-22cc-4a31-9537-8ab35f0034f4"",
                    ""path"": ""<Touchscreen>/primaryTouch/touchId"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""id"": ""c950bb76-c58b-4616-8474-79a620533953"",
                    ""path"": ""PointerInput"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""contact"",
                    ""id"": ""9a4e19bd-8c0c-4a0f-9aa7-5d7550927a6f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""position"",
                    ""id"": ""a4a45123-30d3-4ab3-a52a-667707fd70be"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""delta"",
                    ""id"": ""f7927887-faac-4f8d-add7-709ef29ba3ff"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""inputId"",
                    ""id"": ""7d4d2181-7158-4ef6-b2ea-fd9e0e6750b0"",
                    ""path"": ""<Mouse>/pointerId"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mobile"",
            ""bindingGroup"": ""Mobile"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // MemoryGame
        m_MemoryGame = asset.FindActionMap("MemoryGame", throwIfNotFound: true);
        m_MemoryGame_TouchInput = m_MemoryGame.FindAction("TouchInput", throwIfNotFound: true);
        m_MemoryGame_TouchPress = m_MemoryGame.FindAction("TouchPress", throwIfNotFound: true);
        m_MemoryGame_TouchPosition = m_MemoryGame.FindAction("TouchPosition", throwIfNotFound: true);
        m_MemoryGame_TouchDrag = m_MemoryGame.FindAction("TouchDrag", throwIfNotFound: true);
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_Pointer = m_Touch.FindAction("Pointer", throwIfNotFound: true);
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

    // MemoryGame
    private readonly InputActionMap m_MemoryGame;
    private IMemoryGameActions m_MemoryGameActionsCallbackInterface;
    private readonly InputAction m_MemoryGame_TouchInput;
    private readonly InputAction m_MemoryGame_TouchPress;
    private readonly InputAction m_MemoryGame_TouchPosition;
    private readonly InputAction m_MemoryGame_TouchDrag;
    public struct MemoryGameActions
    {
        private @Controls m_Wrapper;
        public MemoryGameActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchInput => m_Wrapper.m_MemoryGame_TouchInput;
        public InputAction @TouchPress => m_Wrapper.m_MemoryGame_TouchPress;
        public InputAction @TouchPosition => m_Wrapper.m_MemoryGame_TouchPosition;
        public InputAction @TouchDrag => m_Wrapper.m_MemoryGame_TouchDrag;
        public InputActionMap Get() { return m_Wrapper.m_MemoryGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MemoryGameActions set) { return set.Get(); }
        public void SetCallbacks(IMemoryGameActions instance)
        {
            if (m_Wrapper.m_MemoryGameActionsCallbackInterface != null)
            {
                @TouchInput.started -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnTouchInput;
                @TouchInput.performed -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnTouchInput;
                @TouchInput.canceled -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnTouchInput;
                @TouchPress.started -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnTouchPress;
                @TouchPosition.started -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnTouchPosition;
                @TouchDrag.started -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnTouchDrag;
                @TouchDrag.performed -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnTouchDrag;
                @TouchDrag.canceled -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnTouchDrag;
            }
            m_Wrapper.m_MemoryGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchInput.started += instance.OnTouchInput;
                @TouchInput.performed += instance.OnTouchInput;
                @TouchInput.canceled += instance.OnTouchInput;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
                @TouchDrag.started += instance.OnTouchDrag;
                @TouchDrag.performed += instance.OnTouchDrag;
                @TouchDrag.canceled += instance.OnTouchDrag;
            }
        }
    }
    public MemoryGameActions @MemoryGame => new MemoryGameActions(this);

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_Pointer;
    public struct TouchActions
    {
        private @Controls m_Wrapper;
        public TouchActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pointer => m_Wrapper.m_Touch_Pointer;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @Pointer.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPointer;
                @Pointer.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPointer;
                @Pointer.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPointer;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pointer.started += instance.OnPointer;
                @Pointer.performed += instance.OnPointer;
                @Pointer.canceled += instance.OnPointer;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get
        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    public interface IMemoryGameActions
    {
        void OnTouchInput(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnTouchDrag(InputAction.CallbackContext context);
    }
    public interface ITouchActions
    {
        void OnPointer(InputAction.CallbackContext context);
    }
}
