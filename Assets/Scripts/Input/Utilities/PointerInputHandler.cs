using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace MexiColeccion.Input.Utilities
{
    internal sealed class PointerInputHandler : MonoBehaviour
    {
        internal event EventHandler<PointerEventArgs> Pressed;
        internal event EventHandler<PointerEventArgs> Dragged;
        internal event EventHandler<PointerEventArgs> Released;

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
            else if (!drag.Contact && _isDragging)
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
        internal PointerInput PointerInput;
        /// <summary>
        /// The CallbackContext of the InputAction.
        /// </summary>
        internal InputAction.CallbackContext Context;

        internal PointerEventArgs(PointerInput pointerInput, InputAction.CallbackContext context)
        {
            PointerInput = pointerInput;
            Context = context;
        }
    }
}
