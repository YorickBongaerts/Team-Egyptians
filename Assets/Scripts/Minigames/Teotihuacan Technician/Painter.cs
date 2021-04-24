using MexiColeccion.Input;
using MexiColeccion.Input.Utilities;
using MexiColeccion.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MexiColeccion.Minigames.Teotihuacan
{
    public class Painter : InputController
    {
        [Header("References")]
        [Tooltip("Reference to the Display Camera. This is the camera that projects the canvas on the screen. Default is MainCamera.")]
        [SerializeField] private Camera _displayCamera = null;
        [Tooltip("Reference to the SnapShot Camera. This camera will read and save the ink on the canvas and must therefore cull out the reference painting layer. Required.")]
        [SerializeField] private Camera _snapShotCamera = null;
        [Tooltip("Reference to the GameObject where the painting will be displayed on. Required.")]
        [SerializeField] private GameObject _display = null;
        [Tooltip("Reference to the Transform that holds all instantiated brushes. Required.")]
        [SerializeField] private Transform _brushContainer = null;
        [Tooltip("Reference to an instance of the \"UiScriptArtist\" Script that will invoke brush related events. Required.")]
        [SerializeField] private PainterUI _uiScript = null;
        [Header("Painting")]
        [Tooltip("A Prefab that represents the default brush to be used. Must be one that is used in the UI. Required.")]
        [SerializeField] private GameObject _defaultBrush = null;
        [Tooltip("How many instances the object pool of brushes contains.")]
        [SerializeField] private int _maxBrushCount = 1000;
        [Header("Brush")]
        [Tooltip("The bounds of the brush size.\nFormat: MIN, DEFAULT, MAX.")]
        [SerializeField] private Vector3 _brushSize = new Vector3(0.1f, 2.5f, 5f);

        internal bool CanPaint = true; // is there still ink left?

        private Renderer _renderer = null;
        private Sprite _brushSprite;
        private Color _brushColor = Color.black;
        private Rect _snapShotRect;
        private Vector2 _inputPosition;
        private float _scaleUnit = 0.1f;
        private int _brushCounter = 0;
        private bool _isPainting = false;

        private Color BrushColor { get => _brushColor; set => _brushColor = value; }
        private float BrushSize { get => _brushSize.y; set => _brushSize.y = value; }
        internal bool IsPainting => _isPainting;

        #region Unity Lifecycle
        private void Start()
        {
            // do some pre-checks
            // camera
            if (_displayCamera == null)
            {
                _displayCamera = Camera.main;
            }
            _snapShotCamera.transform.position = _displayCamera.transform.position;
            _snapShotCamera.orthographic = _displayCamera.orthographic;
            _snapShotCamera.depth = _displayCamera.depth - 1;

            if (_displayCamera.orthographic)
            {
                _snapShotCamera.orthographicSize = _displayCamera.orthographicSize;
            }
            else
            {
                Debug.LogWarning("The display camera's mode is set to perspective. Painting will not work correctly.");
            }
            Camera.onPostRender += OnPostRenderCallback;

            // renderer
            _renderer = _display.GetComponent<Renderer>();
            if (_renderer == null)
                Debug.LogError("There is no renderer assigned for the display.");

            // set up object pool
            for (int i = 0; i < _maxBrushCount; i++)
            {
                GameObject dot = Instantiate(_defaultBrush, Vector3.zero, Quaternion.identity, _brushContainer);
                dot.name = $"Dot {i}";
                dot.SetActive(false);
            }

            // calculate the pixels of the canvas that have to be read
            int height = Mathf.Min(Mathf.RoundToInt(_display.transform.localScale.y / (_snapShotCamera.orthographicSize * 2f) * Screen.height), Screen.height);
            int width = Mathf.Min(Mathf.RoundToInt((_display.transform.localScale.x / _display.transform.localScale.y) * height), Screen.width);
            int rectX = (int)((Screen.width - width) / 2f);
            int rectY = (int)((Screen.height - height) / 2f);

            _snapShotRect = new Rect(rectX, rectY, width, height);

            // subscribe to the UIScript
            _uiScript.BrushColorChanged += BrushColorChanged;
            _uiScript.BrushShapeChanged += BrushShapeChanged;
            _uiScript.BrushSizeChanged += BrushSizeChanged;
        }

        private void Update()
        {
            if (_isPainting && CanPaint && _brushCounter < _maxBrushCount)
            {
                Vector3 worldPosition = _displayCamera.ScreenToWorldPoint(new Vector3(_inputPosition.x, _inputPosition.y, -_displayCamera.transform.position.z));
                _brushCounter++;
                SetDot(worldPosition, true);
            }
        }

        private void OnDestroy()
        {
            Camera.onPostRender -= OnPostRenderCallback;

            // unsubscribe from UIScript
            _uiScript.BrushColorChanged -= BrushColorChanged;
            _uiScript.BrushShapeChanged -= BrushShapeChanged;
            _uiScript.BrushSizeChanged -= BrushSizeChanged;
        }
        #endregion

        #region Event callbacks
        private void BrushSizeChanged(object sender, BrushSizeChangedEventArgs e)
        {
            BrushSize = Mathf.Clamp(BrushSize + (e.ScaleSign * _scaleUnit), Mathf.Min(_brushSize.x, _brushSize.z), Mathf.Max(_brushSize.x, _brushSize.z));
        }

        private void BrushShapeChanged(object sender, BrushShapeChangedEventArgs e)
        {
            _brushSprite = e.NewShape;
        }

        private void BrushColorChanged(object sender, BrushColorChangedEventArgs e)
        {
            BrushColor = e.NewInk.InkColor;
        }

        private void OnPostRenderCallback(Camera cam)
        {
            if (cam == _snapShotCamera)
            {
                if (_brushCounter >= _maxBrushCount)
                {
                    UpdateTexture();
                    //print("Updated");
                }
            }
        }
        #endregion

        private void SetDot(Vector3 targetPosition, bool activate)
        {
            GameObject dot = _brushContainer.GetChild(_brushCounter - 1).gameObject;

            dot.transform.position = targetPosition;
            dot.SetActive(activate);
            if (activate)
            {
                //_brushShape = Mathf.Clamp(_brushShape, 0, _brushes.Length - 1);
                dot.transform.localScale = new Vector3(BrushSize, BrushSize, 1);
                dot.GetComponent<SpriteRenderer>().sprite = _brushSprite;
                dot.GetComponent<SpriteRenderer>().color = BrushColor;
            }
        }

        private void UpdateTexture()
        {
            Texture2D tex = new Texture2D((int)_snapShotRect.width, (int)_snapShotRect.height, TextureFormat.RGB24, false);
            tex.ReadPixels(_snapShotRect, 0, 0, false);
            tex.Apply();
            _renderer.material.mainTexture = tex;
            // disable brushes
            for (int i = _maxBrushCount - 1; i >= 0; i--)
            {
                SetDot(Vector3.zero, false);
                _brushCounter--;
            }
        }

        #region Debug
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(new Vector3(_snapShotRect.center.x, _snapShotRect.center.y, 0.01f), new Vector3(_snapShotRect.size.x, _snapShotRect.size.y, 0.01f));
        }
        #endregion

        #region Input callbacks
        protected override void OnPressed(object sender, PointerEventArgs e)
        {
            base.OnPressed(sender, e);

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (!_isPainting)
            {
                _isPainting = true;
            }
            else
            {
                throw new Exception("Hmm, this shouldn't be happening...");
            }

            _inputPosition = e.PointerInput.Position;
        }

        protected override void OnDragged(object sender, PointerEventArgs e)
        {
            base.OnDragged(sender, e);

            _inputPosition = e.PointerInput.Position;
        }

        protected override void OnReleased(object sender, PointerEventArgs e)
        {
            base.OnReleased(sender, e);

            _isPainting = false;
        }
        #endregion
    }
}