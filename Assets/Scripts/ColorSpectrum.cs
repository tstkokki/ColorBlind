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
        Purple = 5,
        Black = 6
    }

    Color[] colors = new Color[]{
        Color.white, Color.red, Color.green, Color.blue, Color.yellow, Color.magenta, Color.black
    };
    public ColorSpec currentSpec = ColorSpec.White;
    public Color GetColor(ColorSpec _spec)
    {
        return colors[(int)_spec];
    }


    public void ChangeColor(int _i)
    {
        if(_i > 3)
        {
            currentSpec = ColorSpec.White;
            return;
        }
        if(_i < 0)
        {
            currentSpec = ColorSpec.Blue;
            return;
        }
        currentSpec = (ColorSpec)_i;

    }
}
