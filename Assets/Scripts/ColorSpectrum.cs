using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSpectrum
{
    public enum ColorSpec
    {
        White = 0,
        Red = 1,
        Green = 2,
        Blue = 3,
        Yellow = 4,
        Purple = 5
    }

    Color[] colors = new Color[]{
        Color.white, Color.red, Color.green, Color.blue, Color.yellow, Color.magenta
    };
    public ColorSpec currentSpec = ColorSpec.White;
    public Color GetColor(ColorSpec _spec)
    {
        return colors[(int)_spec];
    }


    public void ChangeColor(int _i)
    {
        if(_i > 5)
        {
            currentSpec = ColorSpec.Red;
            return;
        }
        if(_i < 0)
        {
            currentSpec = ColorSpec.Purple;
            return;
        }
        currentSpec = (ColorSpec)_i;

    }
}
