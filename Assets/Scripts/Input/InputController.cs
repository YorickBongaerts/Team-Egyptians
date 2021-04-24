using MexiColeccion.Input.Utilities;
using MexiColeccion.Utils.Debug;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace MexiColeccion.Input
{
    /// <summary>
    /// InputController is the base input class from which a class that needs to handle input derives. Override the event callbacks in order to use the pointer input.
    /// </summary>
    public class InputController : MonoBehaviour
    {
        [Header("Auto-assigned fields")]
        [SerializeField] private InputDebugger _debugger;
        [SerializeField] private GameObject _inputHandlerGO;

        private PointerInputHandler _inputHandler;
        private Swipe _activeSwipe;

        private InputDebugger Debugger => _debugger;
        private PointerInputHandler InputHandler
        {
            get => _inputHandler;
            set
            {
                if (InputHandler != null)
                {
                    UnsubscribeFromInputHandler();
                }
                _inputHandler = value;
                if (InputHandler != null)
                {
                    SubscribeToInputHandler();
                }
            }
        }

        #region Unity Lifecycle
        private void Reset()
        {
            SetInputHandlerSceneObject();
        }

        private void Start()
        {
            if (_inputHandlerGO == null)
            {
                SetInputHandlerSceneObject();
            }
            if (_inputHandler == null)
                InputHandler = _inputHandlerGO.GetComponent<PointerInputHandler>();
        }

        private void OnEnable()
        {
            if (_inputHandlerGO == null)
            {
                SetInputHandlerSceneObject();
            }
            if (_inputHandler == null)
                InputHandler = _inputHandlerGO.GetComponent<PointerInputHandler>();
            //SubscribeToInputHandler();
        }

        private void OnDisable()
        {
            //UnsubscribeFromInputHandler();
            if (_inputHandler != null)
                InputHandler = null;
        }

        private void OnDestroy()
        {
            if (_inputHandler != null)
                InputHandler = null;
        }
        #endregion

        #region Virtual Input Events
        /// <summary>
        /// Event called when the user starts touching the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnPressed(object sender, PointerEventArgs e)
        {
            if (EventSystem.current.IsPointerOverGameObject(e.PointerInput.InputId))
            {
                Debug.Log("Pointer over UI.");
                return;
            }

            e.PointerInput.StartTime = e.Context.time;
            _activeSwipe = new Swipe(e.PointerInput);
            _activeSwipe.StartPosition = e.PointerInput.Position;
            e.PointerInput.Swipe = _activeSwipe;

            if (Debugger != null)
            {
                Debugger.DebugInfo(e.PointerInput);
            }
        }

        /// <summary>
        /// Event called when the user is moving their finger while touching the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnDragged(object sender, PointerEventArgs e)
        {
            e.PointerInput.EndTime = e.Context.time;
            _activeSwipe.EndPosition = e.PointerInput.Position;
            _activeSwipe.Delta = e.PointerInput.Delta;
            e.PointerInput.Swipe = _activeSwipe;

            //if (IsValidSwipe(e))
            //{
                //e.PointerInput.SubmitPoint(e.Context);
            //}

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
            e.PointerInput.EndTime = e.Context.time;
            _activeSwipe.EndPosition = e.PointerInput.Position;
            e.PointerInput.Swipe = _activeSwipe;
            
            //if (IsValidSwipe(e))
            //{
                //e.PointerInput.SubmitPoint(e.Context);
            //}

            if (Debugger != null)
            {
                Debugger.DebugInfo(e.PointerInput);
            }
        }
        #endregion

        //private bool IsValidSwipe(PointerEventArgs e)
        //{
        //    return e.Context.duration > 0 && e.Context.duration < _maxSwipeDuration && e.PointerInput.Swipe.Distance > _minSwipeDistance;
        //}

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

        private void SetInputHandlerSceneObject()
        {
            GameObject section = GameObject.Find("==== DO NOT DELETE ====");
            if (section == null)
            {
                section = new GameObject("==== DO NOT DELETE ====");
                section.tag = "EditorOnly";
            }

            _inputHandlerGO = GameObject.Find("PointerInputHandler [Auto-generated]");
            if (_inputHandlerGO == null)
            {
                _inputHandlerGO = new GameObject("PointerInputHandler [Auto-generated]", typeof(PointerInputHandler));
            }
            
            _debugger = GameObject.Find("DebugPanel")?.GetComponent<InputDebugger>();
            if(_debugger == null)
            {
                print("No InputDebugger Detected. Create a new InputDebugger if you want to debug the input. An InputDebugger must have a text component.");
            }
        }
    }
}