using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScriptArtist : UIScript
{
    public event EventHandler<BrushColorChangedEventArgs> BrushColorChanged;
    public event EventHandler<BrushSizeChangedEventArgs> BrushSizeChanged;
    public event EventHandler<BrushShapeChangedEventArgs> BrushShapeChanged;

    public void OnBrushColorChanged(Image image)
    {
        Color color = image.color;
        EventHandler<BrushColorChangedEventArgs> handler = BrushColorChanged;
        handler?.Invoke(this, new BrushColorChangedEventArgs(color));
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
    public Color NewColor;

    public BrushColorChangedEventArgs(Color newColor)
    {
        NewColor = newColor;
    }
}
