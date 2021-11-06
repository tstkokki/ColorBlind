using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBehaviour : MonoBehaviour
{
    [SerializeField] protected ColorData_SO _colorData;
    protected SpriteRenderer renderer;

    [SerializeField] protected ColorSpectrum.ColorSpec _mySpec;
    // Start is called before the first frame update
    protected void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(ColorSpectrum.ColorSpec _spec)
    {
        _mySpec = _spec;
        renderer.color = _colorData.colorData.GetColor(_mySpec);
    }

    public void ChangeColor(Color _color)
    {
        renderer.color = _color;
    }

    virtual protected void Behaviours()
    {

    }
}
