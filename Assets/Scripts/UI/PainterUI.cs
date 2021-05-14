using MexiColeccion.Minigames.Teotihuacan;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.UI
{
    public class PainterUI : MinigameBaseUI
    {
        internal event EventHandler<BrushColorChangedEventArgs> BrushColorChanged;
        internal event EventHandler<BrushSizeChangedEventArgs> BrushSizeChanged;
        internal event EventHandler<BrushShapeChangedEventArgs> BrushShapeChanged;

        [SerializeField] private Transform _referenceQuad;
        [SerializeField] private Text _scoreDisplay;
        [SerializeField] private Image _displayIcon;
        [SerializeField] private Sprite _display, _hide;
        [SerializeField] private AccuracyChecker _ac;

        private bool _isDisplayingPainting = false;

        public void OnBrushColorChanged(Ink ink)
        {
            _soundManager.PlayButtonTap();
            EventHandler<BrushColorChangedEventArgs> handler = BrushColorChanged;
            handler?.Invoke(this, new BrushColorChangedEventArgs(ink));
        }

        public void OnBrushSizeChanged(float scaleSign)
        {
            _soundManager.PlayButtonTap();
            EventHandler<BrushSizeChangedEventArgs> handler = BrushSizeChanged;
            handler?.Invoke(this, new BrushSizeChangedEventArgs(scaleSign));
        }

        public void OnBrushShapeChanged(Sprite newShape)
        {
            _soundManager.PlayButtonTap();
            EventHandler<BrushShapeChangedEventArgs> handler = BrushShapeChanged;
            handler?.Invoke(this, new BrushShapeChangedEventArgs(newShape));
        }

        public void OnFinishGame()
        {
            _ac.OnEndGame();
        }

        public void OnDisplayAndHidePainting()
        {
            if (_isDisplayingPainting)
            {
                _soundManager.PlayButtonTap();
                _referenceQuad.position += new Vector3(0, 0, 10);
                _isDisplayingPainting = false;
                _scoreDisplay.text = "";
                _displayIcon.sprite = _display;
            }
            else
            {
                _soundManager.PlayButtonTap();

                _ac.CalculateScore();
                StartCoroutine(WaitForTextureUpdate());
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private IEnumerator WaitForTextureUpdate()
        {
            yield return new WaitForSeconds(Time.deltaTime * 2);

            _referenceQuad.position += new Vector3(0, 0, -10);
            _isDisplayingPainting = true;
            _scoreDisplay.text = _ac.CurrentScore + "%";
            _displayIcon.sprite = _hide;
        }
    }

    internal class BrushShapeChangedEventArgs : EventArgs
    {
        internal Sprite NewShape;

        internal BrushShapeChangedEventArgs(Sprite newShape)
        {
            NewShape = newShape;
        }
    }

    internal class BrushSizeChangedEventArgs : EventArgs
    {
        internal float ScaleSign;

        internal BrushSizeChangedEventArgs(float scaleSign)
        {
            ScaleSign = scaleSign;
        }
    }

    internal class BrushColorChangedEventArgs : EventArgs
    {
        internal Ink NewInk;

        internal BrushColorChangedEventArgs(Ink newInk)
        {
            NewInk = newInk;
        }
    }
}