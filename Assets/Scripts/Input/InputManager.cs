using MexiColleccion.Input.Utilities;
using MexiColleccion.Utils.Debug;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MexiColleccion.Input
{
    /// <summary>
    /// InputManager is the base input class from which a class that needs to handle input derives. Override the event callbacks in order to use the pointer input.
    /// </summary>
    [RequireComponent(typeof(PointerInputHandler))]
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private InputDebugger _debugger;
        private PointerInputHandler _inputHandler;

        private PointerInputHandler InputHandler => _inputHandler;
        private InputDebugger Debugger => _debugger;

        #region Unity Lifecycle
        private void OnEnable()
        {
            _inputHandler = GetComponent<PointerInputHandler>();
            SubscribeToInputHandler();
        }

        private void OnDisable()
        {
            UnsubscribeFromInputHandler();
            _inputHandler = null;
        }
        #endregion

        private void SubscribeToInputHandler()
        {
            InputHandler.Pressed += OnPressed;
            InputHandler.Dragged += OnDragged;
            InputHandler.Released += OnReleased;
        }

        private void UnsubscribeFromInputHandler()
        {
            InputHandler.Pressed -= OnPressed;
            InputHandler.Dragged -= OnDragged;
            InputHandler.Released -= OnReleased;
        }

        /// <summary>
        /// Event called when the user starts touching the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnPressed(object sender, PointerEventArgs e)
        {
            if (Debugger != null)
            {
                Debugger.DebugInfo(e.PointerInput);
            }

            if (EventSystem.current.IsPointerOverGameObject(e.PointerInput.InputId))
                return;
        }

        /// <summary>
        /// Event called when the user is moving their finger while touching the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnDragged(object sender, PointerEventArgs e)
        {
            if (Debugger != null)
            {
                Debugger.DebugInfo(e.PointerInput);
            }
        }

        /// <summary>
        /// Event called when the user stops touching the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnReleased(object sender, PointerEventArgs e)
        {
            if (Debugger != null)
            {
                Debugger.DebugInfo(e.PointerInput);
            }
        }

    }
}