using MexiColeccion.Minigames.Teotihuacan;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.UI
{
    public class PainterUI : MinigameBaseUI
    {
        internal event EventHandler<BrushColorChangedEventArgs> BrushColorChanged;
        internal event EventHandler<BrushSizeChangedEventArgs> BrushSizeChanged;
        internal event EventHandler<BrushShapeChangedEventArgs> BrushShapeChanged;

        private bool _isDisplayingPainting = false;
        public Transform ReferenceQuad;
        public Text ScoreDisplay;
        public Image DisplayIcon;
        public Sprite Display, Hide;
        public AccuracyChecker Ac;
        public SoundManager SoundManager;

        public void OnBrushColorChanged(Ink ink)
        {
            SoundManager.PlayButtonTap();
            EventHandler<BrushColorChangedEventArgs> handler = BrushColorChanged;
            handler?.Invoke(this, new BrushColorChangedEventArgs(ink));
        }

        public void OnBrushSizeChanged(float scaleSign)
        {
            SoundManager.PlayButtonTap();
            EventHandler<BrushSizeChangedEventArgs> handler = BrushSizeChanged;
            handler?.Invoke(this, new BrushSizeChangedEventArgs(scaleSign));
        }

        public void OnBrushShapeChanged(Sprite newShape)
        {
            SoundManager.PlayButtonTap();
            EventHandler<BrushShapeChangedEventArgs> handler = BrushShapeChanged;
            handler?.Invoke(this, new BrushShapeChangedEventArgs(newShape));
        }

        public void OnDisplayAndHidePainting()
        {
            if(_isDisplayingPainting)
            {
                SoundManager.PlayButtonTap();
                ReferenceQuad.position += new Vector3(0, 0, 10);
                _isDisplayingPainting = false;
                ScoreDisplay.text = "";
                DisplayIcon.sprite = Display;
            }
            else
            {
                SoundManager.PlayButtonTap();
                ReferenceQuad.position += new Vector3(0, 0, -10);
                _isDisplayingPainting = true;
                ScoreDisplay.text = Ac.CalculateScore() + "%";
                DisplayIcon.sprite = Hide;
            }
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