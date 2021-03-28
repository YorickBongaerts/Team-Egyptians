using MexiColleccion.Minigames.Teotihuacan;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColleccion.UI
{
    public class UiScriptArtist : UIScript
    {
        public event EventHandler<BrushColorChangedEventArgs> BrushColorChanged;
        public event EventHandler<BrushSizeChangedEventArgs> BrushSizeChanged;
        public event EventHandler<BrushShapeChangedEventArgs> BrushShapeChanged;

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

    public class BrushShapeChangedEventArgs : EventArgs
    {
        public Sprite NewShape;

        public BrushShapeChangedEventArgs(Sprite newShape)
        {
            NewShape = newShape;
        }
    }

    public class BrushSizeChangedEventArgs : EventArgs
    {
        public float ScaleSign;

        public BrushSizeChangedEventArgs(float scaleSign)
        {
            ScaleSign = scaleSign;
        }
    }

    public class BrushColorChangedEventArgs : EventArgs
    {
        public Ink NewInk;

        public BrushColorChangedEventArgs(Ink newInk)
        {
            NewInk = newInk;
        }
    }
}