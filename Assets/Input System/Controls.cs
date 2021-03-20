// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

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
                    ""type"": ""Button"",
                    ""id"": ""0c2a2ca7-380f-433a-958d-70fc4b10a3a5"",
                    ""expectedControlType"": ""Button"",
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
                    ""groups"": """",
                    ""action"": ""Tap"",
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
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""9a9e6a2a-ab46-48a2-804e-b0d92a581855"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d9d4ca5a-ca57-4482-90ea-4feb0f04d1ba"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
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
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""6e0c269e-2bce-495e-aefe-6f29c325446b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bf24e541-58fa-4d97-a632-a206825cffbe"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Tap = m_Menu.FindAction("Tap", throwIfNotFound: true);
        // MainHub
        m_MainHub = asset.FindActionMap("MainHub", throwIfNotFound: true);
        m_MainHub_Tap = m_MainHub.FindAction("Tap", throwIfNotFound: true);
        // MemoryGame
        m_MemoryGame = asset.FindActionMap("MemoryGame", throwIfNotFound: true);
        m_MemoryGame_Newaction = m_MemoryGame.FindAction("New action", throwIfNotFound: true);
        // Teotihuacan
        m_Teotihuacan = asset.FindActionMap("Teotihuacan", throwIfNotFound: true);
        m_Teotihuacan_Newaction = m_Teotihuacan.FindAction("New action", throwIfNotFound: true);
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
    public struct MenuActions
    {
        private @Controls m_Wrapper;
        public MenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_Menu_Tap;
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
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tap.started += instance.OnTap;
                @Tap.performed += instance.OnTap;
                @Tap.canceled += instance.OnTap;
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
    private readonly InputAction m_MemoryGame_Newaction;
    public struct MemoryGameActions
    {
        private @Controls m_Wrapper;
        public MemoryGameActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_MemoryGame_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_MemoryGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MemoryGameActions set) { return set.Get(); }
        public void SetCallbacks(IMemoryGameActions instance)
        {
            if (m_Wrapper.m_MemoryGameActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MemoryGameActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MemoryGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MemoryGameActions @MemoryGame => new MemoryGameActions(this);

    // Teotihuacan
    private readonly InputActionMap m_Teotihuacan;
    private ITeotihuacanActions m_TeotihuacanActionsCallbackInterface;
    private readonly InputAction m_Teotihuacan_Newaction;
    public struct TeotihuacanActions
    {
        private @Controls m_Wrapper;
        public TeotihuacanActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Teotihuacan_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Teotihuacan; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TeotihuacanActions set) { return set.Get(); }
        public void SetCallbacks(ITeotihuacanActions instance)
        {
            if (m_Wrapper.m_TeotihuacanActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_TeotihuacanActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_TeotihuacanActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_TeotihuacanActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_TeotihuacanActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public TeotihuacanActions @Teotihuacan => new TeotihuacanActions(this);
    public interface IMenuActions
    {
        void OnTap(InputAction.CallbackContext context);
    }
    public interface IMainHubActions
    {
        void OnTap(InputAction.CallbackContext context);
    }
    public interface IMemoryGameActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface ITeotihuacanActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
