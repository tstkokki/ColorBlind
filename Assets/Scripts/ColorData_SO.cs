using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Color Data", menuName ="Custom/Color Data")]
public class ColorData_SO : ScriptableObject
{
    public ColorSpectrum colorData = new ColorSpectrum();

    private void OnEnable()
    {
        colorData.currentSpec = ColorSpectrum.ColorSpec.White;
    }
}
