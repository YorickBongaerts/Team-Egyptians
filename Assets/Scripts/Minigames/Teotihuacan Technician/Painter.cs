using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace MexiColleccion.Minigames
{
    public class Painter : MonoBehaviour
    {
        [SerializeField] private GameObject _display = null;
        [SerializeField] private Transform _brushContainer = null;
        [Header("Painting")]
        [SerializeField] private GameObject[] _brushes = null;
        [SerializeField] private int _maxBrushCount = 1000;
        [Header("Brush")]
        [SerializeField] private float _brushSize = 3.0f;
        [SerializeField] private int _brushShape = 0;

        private Renderer _renderer = null;
        private Vector2 _inputPosition;
        private int _brushCounter = 0;
        private bool _isPainting = false;
        private bool _canPaint = true; // is there still ink left?

        void Start()
        {
            Camera.onPostRender += OnPostRenderCallback;
            _brushShape = Mathf.Clamp(_brushShape, 0, _brushes.Length - 1);

            // set up object pool
            for (int i = 0; i < _maxBrushCount; i++)
            {
                GameObject dot = Instantiate(_brushes[_brushShape], Vector3.zero, Quaternion.identity, _brushContainer);
                dot.name = $"Dot {i}";
                dot.SetActive(false);
            }

            _renderer = _display.GetComponent<Renderer>();

            // do some pre-checks
            if (_renderer == null)
                Debug.LogError("There is no renderer assigned.");
            if (!Camera.main.orthographic)
                Debug.LogWarning("The display camera's mode is set to perspective. Painting will not work correctly.");
        }

        void OnPostRenderCallback(Camera cam)
        {
            if (cam == Camera.main)
            {
                if (_brushCounter >= _maxBrushCount)
                {
                    UpdateTexture();
                    print("Updated");
                }
            }
        }

        void Update()
        {
            if (_isPainting && _brushCounter < _maxBrushCount)
            {
                //Vector2 inputPosition = UnityEngine.Input.GetTouch(0).position;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(_inputPosition.x, _inputPosition.y, -Camera.main.transform.position.z));
                _brushCounter++;
                SetDot(worldPosition, true);
            }
        }

        private void SetDot(Vector3 targetPosition, bool activate)
        {
            GameObject dot = _brushContainer.GetChild(_brushCounter - 1).gameObject;

            dot.transform.position = targetPosition;
            // -- scale, shape and color can easily be added --
            dot.transform.localScale = new Vector3(_brushSize, _brushSize, 1);
            dot.GetComponent<SpriteRenderer>().sprite = _brushes[_brushShape].GetComponent<SpriteRenderer>().sprite;

            dot.SetActive(activate);
        }

        public void OnPaint(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                if (!_isPainting)
                {
                    _isPainting = true;
                }
                return;
            }
            _isPainting = false;
        }

        public void OnTapPosition(InputAction.CallbackContext context)
        {
            TouchControl control = context.control.parent as TouchControl;
            _inputPosition = control.position.ReadValue();
        }

        void UpdateTexture()
        {
            int width = (int)((_display.transform.localScale.x / Camera.main.orthographicSize) * 360);
            int height = (int)((_display.transform.localScale.y / Camera.main.orthographicSize) * 360);
            Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
            tex.ReadPixels(new Rect(0, 0, width, height), 0, 0, false);
            tex.Apply();
            _renderer.material.mainTexture = tex;
            // disable brushes
            for (int i = _maxBrushCount - 1; i >= 0; i--)
            {
                SetDot(Vector3.zero, false);
                _brushCounter--;
            }
        }

        void OnDestroy()
        {
            Camera.onPostRender -= OnPostRenderCallback;
        }
    }
}