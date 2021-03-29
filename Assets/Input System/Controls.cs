// GENERATED AUTOMATICALLY FROM 'Assets/Input System/Controls.inputactions'

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
                    ""type"": ""Button"",
                    ""id"": ""cc213b6a-08aa-4ef6-a629-70c319929dbb"",
                    ""expectedControlType"": ""Button"",
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
            ""name"": ""Teotihuacan"",
            ""id"": ""5b3ec4ec-90ca-4e62-9512-b56a7c39d5c3"",
            ""actions"": [
                {
                    ""name"": ""Paint"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6e0c269e-2bce-495e-aefe-6f29c325446b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TapPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""74ee284b-80dc-4370-aac7-edee47ce07c9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a55c15cc-eac3-4a91-8b7a-bb17b13dc7be"",
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
                    ""id"": ""fe4640ad-8021-4b40-8542-107f42172cc2"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Paint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
        // MemoryGame
        m_MemoryGame = asset.FindActionMap("MemoryGame", throwIfNotFound: true);
        m_MemoryGame_TouchInput = m_MemoryGame.FindAction("TouchInput", throwIfNotFound: true);
        m_MemoryGame_TouchPress = m_MemoryGame.FindAction("TouchPress", throwIfNotFound: true);
        m_MemoryGame_TouchPosition = m_MemoryGame.FindAction("TouchPosition", throwIfNotFound: true);
        m_MemoryGame_TouchDrag = m_MemoryGame.FindAction("TouchDrag", throwIfNotFound: true);
        // Teotihuacan
        m_Teotihuacan = asset.FindActionMap("Teotihuacan", throwIfNotFound: true);
        m_Teotihuacan_Paint = m_Teotihuacan.FindAction("Paint", throwIfNotFound: true);
        m_Teotihuacan_TapPosition = m_Teotihuacan.FindAction("TapPosition", throwIfNotFound: true);
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
    public struct MainHubActions
    {
        private @Controls m_Wrapper;
        public MainHubActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_MainHub_Tap;
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
            }
            m_Wrapper.m_MainHubActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tap.started += instance.OnTap;
                @Tap.performed += instance.OnTap;
                @Tap.canceled += instance.OnTap;
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

    // Teotihuacan
    private readonly InputActionMap m_Teotihuacan;
    private ITeotihuacanActions m_TeotihuacanActionsCallbackInterface;
    private readonly InputAction m_Teotihuacan_Paint;
    private readonly InputAction m_Teotihuacan_TapPosition;
    public struct TeotihuacanActions
    {
        private @Controls m_Wrapper;
        public TeotihuacanActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Paint => m_Wrapper.m_Teotihuacan_Paint;
        public InputAction @TapPosition => m_Wrapper.m_Teotihuacan_TapPosition;
        public InputActionMap Get() { return m_Wrapper.m_Teotihuacan; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TeotihuacanActions set) { return set.Get(); }
        public void SetCallbacks(ITeotihuacanActions instance)
        {
            if (m_Wrapper.m_TeotihuacanActionsCallbackInterface != null)
            {
                @Paint.started -= m_Wrapper.m_TeotihuacanActionsCallbackInterface.OnPaint;
                @Paint.performed -= m_Wrapper.m_TeotihuacanActionsCallbackInterface.OnPaint;
                @Paint.canceled -= m_Wrapper.m_TeotihuacanActionsCallbackInterface.OnPaint;
                @TapPosition.started -= m_Wrapper.m_TeotihuacanActionsCallbackInterface.OnTapPosition;
                @TapPosition.performed -= m_Wrapper.m_TeotihuacanActionsCallbackInterface.OnTapPosition;
                @TapPosition.canceled -= m_Wrapper.m_TeotihuacanActionsCallbackInterface.OnTapPosition;
            }
            m_Wrapper.m_TeotihuacanActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Paint.started += instance.OnPaint;
                @Paint.performed += instance.OnPaint;
                @Paint.canceled += instance.OnPaint;
                @TapPosition.started += instance.OnTapPosition;
                @TapPosition.performed += instance.OnTapPosition;
                @TapPosition.canceled += instance.OnTapPosition;
            }
        }
    }
    public TeotihuacanActions @Teotihuacan => new TeotihuacanActions(this);
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
    }
    public interface IMemoryGameActions
    {
        void OnTouchInput(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnTouchDrag(InputAction.CallbackContext context);
    }
    public interface ITeotihuacanActions
    {
        void OnPaint(InputAction.CallbackContext context);
        void OnTapPosition(InputAction.CallbackContext context);
    }
}
