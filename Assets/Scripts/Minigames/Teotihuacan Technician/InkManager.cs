using MexiColeccion.UI;
using UnityEngine;

namespace MexiColeccion.Minigames.Teotihuacan
{
    public class InkManager : MonoBehaviour
    {
        [Header("References")]
        [Tooltip("Reference to an instance of the \"Painter\" Script")]
        [SerializeField] private Painter _painterScript = null;
        [Tooltip("Reference to an instance of the \"UiScriptArtist\" Script")]
        [SerializeField] private PainterUI _uiScript = null;
        [Header("Ink")]
        [Tooltip("The speed at which ink gets used when painting. Measured in ml/s.")]
        [SerializeField] private float _inkDropRate = 10f;

        private Ink _currentInk = null;
        private float _inkRemaining = 0f;

        private void Start()
        {
            // subscribe to the UI Script
            _uiScript.BrushColorChanged += BrushColorChanged;
        }

        private void Update()
        {
            if (_painterScript.IsPainting && _inkRemaining > 0f)
            {
                _inkRemaining -= _inkDropRate * Time.deltaTime;
                if (_inkRemaining <= 0f)
                {
                    _inkRemaining = 0f;
                    _painterScript.CanPaint = false;
                    print($"Out of {_currentInk.InkColor} ink.");
                }
                //Debug.Log(_inkPercentage);
            }
        }

        private void OnDestroy()
        {
            // unsubscribe from the UI Script
            _uiScript.BrushColorChanged -= BrushColorChanged;
        }

        private void BrushColorChanged(object sender, BrushColorChangedEventArgs e)
        {
            // set the percentage of the last used ink to the used amount
            if (_currentInk != null)
            {
                _currentInk.InkRemaining = _inkRemaining;
            }

            // assign the new ink
            _currentInk = e.NewInk;
            _inkRemaining = _currentInk.InkRemaining;

            // check if the new ink container still has ink left
            if (!_painterScript.CanPaint && _inkRemaining > 0f)
            {
                _painterScript.CanPaint = true;
            }
        }
    }
}