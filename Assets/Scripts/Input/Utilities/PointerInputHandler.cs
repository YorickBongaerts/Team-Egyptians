using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace MexiColleccion.Input.Utilities
{
    public sealed class PointerInputHandler : MonoBehaviour
    {
        public event EventHandler<PointerEventArgs> Pressed;
        public event EventHandler<PointerEventArgs> Dragged;
        public event EventHandler<PointerEventArgs> Released;

        private Controls _controlsActions;
        private bool _isDragging;

        [SerializeField] private bool _isUsingPen;
        [SerializeField] private bool _isUsingTouch;

        private void Awake()
        {
            _controlsActions = new Controls();

            _controlsActions.Touch.Pointer.performed += OnTouch;
            _controlsActions.Touch.Pointer.canceled += OnTouch;
        }

        private void OnEnable()
        {
            _controlsActions?.Enable();
        }

        private void OnDisable()
        {
            _controlsActions?.Disable();
        }

        private void OnTouch(InputAction.CallbackContext context)
        {
            InputControl control = context.control;
            InputDevice device = control.device;

            bool isMouseInput = device is Mouse;

            // Read our current pointer values.
            PointerInput drag = context.ReadValue<PointerInput>();
            if (isMouseInput)
                drag.InputId = PointerInputModule.kMouseLeftId;

            if (drag.Contact && !_isDragging)
            {
                Pressed?.Invoke(this, new PointerEventArgs(drag, context));
                _isDragging = true;
            }
            else if (drag.Contact && _isDragging)
            {
                Dragged?.Invoke(this, new PointerEventArgs(drag, context));
            }
            else
            {
                Released?.Invoke(this, new PointerEventArgs(drag, context));
                _isDragging = false;
            }
        }
    }

    public class PointerEventArgs : EventArgs
    {
        /// <summary>
        /// Simple object that contains information for touch inputs.
        /// </summary>
        public PointerInput PointerInput;
        /// <summary>
        /// The CallbackContext of the InputAction (might be redundant).
        /// </summary>
        public InputAction.CallbackContext Context;

        public PointerEventArgs(PointerInput pointerInput, InputAction.CallbackContext context)
        {
            PointerInput = pointerInput;
            Context = context;
        }
    }
}
