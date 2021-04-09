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
            ""name"": ""Menu"",
            ""id"": ""54ab54ac-8364-4944-87ec-324f16fc4d4d"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0c2a2ca7-380f-433a-958d-70fc4b10a3a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9908a6ca-5eb0-4436-850a-54b31f7729ef"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""72e32880-b1a9-44c7-bb88-6b40c31a04c5"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86840292-734c-408f-9f00-d688d0715e8c"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainHub"",
            ""id"": ""50a1de51-81c3-4dbf-a510-b20553408158"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cc213b6a-08aa-4ef6-a629-70c319929dbb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TapPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9d05a432-48ab-49bd-8b41-335d5278f5ff"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""842799d2-cfb9-4ac4-a1a6-38b5c645d445"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""503f9ea3-6230-4b3e-8039-aea5c5376525"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcaf7d83-14bc-4c85-9288-d4d94da7af05"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""TapPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae772b17-2f2b-4e64-b5b3-0908d40c6275"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TapPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
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
                    ""id"": ""04dca819-b41d-40fe-a464-728d39f50586"",
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
                    ""id"": ""2cfc1359-f27c-40b2-a3fd-de74c48292f9"",
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
                    ""id"": ""99ebf1cd-ddde-46a0-a221-e2ff53ff194c"",
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
                    ""id"": ""fa55728b-1a3d-4805-b015-4e9055561a5f"",
                    ""path"": ""<Touchscreen>/primaryTouch/radius"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""pressure"",
                    ""id"": ""26e2616f-1825-4bf7-9734-cbf88f0ea7c9"",
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
                    ""id"": ""0c8908a3-282a-439d-af3b-50f64a493816"",
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
                    ""id"": ""3ebd7a51-52ff-49a9-ba8d-34e9cdcb4612"",
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
                    ""id"": ""abbcdfab-6c2a-4ba8-b35f-60ce05baf525"",
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
                    ""id"": ""183d81d0-017c-4000-8f67-733314166780"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""inputId"",
                    ""id"": ""28a04dec-333d-4ee6-bcb1-59cae775382a"",
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
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Tap = m_Menu.FindAction("Tap", throwIfNotFound: true);
        m_Menu_Point = m_Menu.FindAction("Point", throwIfNotFound: true);
        // MainHub
        m_MainHub = asset.FindActionMap("MainHub", throwIfNotFound: true);
        m_MainHub_Tap = m_MainHub.FindAction("Tap", throwIfNotFound: true);
        m_MainHub_TapPosition = m_MainHub.FindAction("TapPosition", throwIfNotFound: true);
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

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Tap;
    private readonly InputAction m_Menu_Point;
    public struct MenuActions
    {
        private @Controls m_Wrapper;
        public MenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_Menu_Tap;
        public InputAction @Point => m_Wrapper.m_Menu_Point;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Tap.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnTap;
                @Tap.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnTap;
                @Tap.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnTap;
                @Point.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnPoint;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tap.started += instance.OnTap;
                @Tap.performed += instance.OnTap;
                @Tap.canceled += instance.OnTap;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);

    // MainHub
    private readonly InputActionMap m_MainHub;
    private IMainHubActions m_MainHubActionsCallbackInterface;
    private readonly InputAction m_MainHub_Tap;
    private readonly InputAction m_MainHub_TapPosition;
    public struct MainHubActions
    {
        private @Controls m_Wrapper;
        public MainHubActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_MainHub_Tap;
        public InputAction @TapPosition => m_Wrapper.m_MainHub_TapPosition;
        public InputActionMap Get() { return m_Wrapper.m_MainHub; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainHubActions set) { return set.Get(); }
        public void SetCallbacks(IMainHubActions instance)
        {
            if (m_Wrapper.m_MainHubActionsCallbackInterface != null)
            {
                @Tap.started -= m_Wrapper.m_MainHubActionsCallbackInterface.OnTap;
                @Tap.performed -= m_Wrapper.m_MainHubActionsCallbackInterface.OnTap;
                @Tap.canceled -= m_Wrapper.m_MainHubActionsCallbackInterface.OnTap;
                @TapPosition.started -= m_Wrapper.m_MainHubActionsCallbackInterface.OnTapPosition;
                @TapPosition.performed -= m_Wrapper.m_MainHubActionsCallbackInterface.OnTapPosition;
                @TapPosition.canceled -= m_Wrapper.m_MainHubActionsCallbackInterface.OnTapPosition;
            }
            m_Wrapper.m_MainHubActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tap.started += instance.OnTap;
                @Tap.performed += instance.OnTap;
                @Tap.canceled += instance.OnTap;
                @TapPosition.started += instance.OnTapPosition;
                @TapPosition.performed += instance.OnTapPosition;
                @TapPosition.canceled += instance.OnTapPosition;
            }
        }
    }
    public MainHubActions @MainHub => new MainHubActions(this);

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
    public interface IMenuActions
    {
        void OnTap(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
    }
    public interface IMainHubActions
    {
        void OnTap(InputAction.CallbackContext context);
        void OnTapPosition(InputAction.CallbackContext context);
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
