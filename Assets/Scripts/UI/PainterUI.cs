using MexiColeccion.Minigames.Teotihuacan;
using System;
using UnityEngine;

namespace MexiColeccion.UI
{
    public class PainterUI : MinigameBaseUI
    {
        internal event EventHandler<BrushColorChangedEventArgs> BrushColorChanged;
        internal event EventHandler<BrushSizeChangedEventArgs> BrushSizeChanged;
        internal event EventHandler<BrushShapeChangedEventArgs> BrushShapeChanged;

        public void OnBrushColorChanged(Ink ink)
        {
            EventHandler<BrushColorChangedEventArgs> handler = BrushColorChanged;
            handler?.Invoke(this, new BrushColorChangedEventArgs(ink));
        }

        public void OnBrushSizeChanged(float scaleSign)
        {
            EventHandler<BrushSizeChangedEventArgs> handler = BrushSizeChanged;
            handler?.Invoke(this, new BrushSizeChangedEventArgs(scaleSign));
        }

        public void OnBrushShapeChanged(Sprite newShape)
        {
            EventHandler<BrushShapeChangedEventArgs> handler = BrushShapeChanged;
            handler?.Invoke(this, new BrushShapeChangedEventArgs(newShape));
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