using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBehaviour : MonoBehaviour
{
    [SerializeField] protected ColorData_SO _colorData;
    protected SpriteRenderer renderer;

    [SerializeField] protected ColorSpectrum.ColorSpec _mySpec;

    Vector3 startPos;
    // Start is called before the first frame update
    protected void Start()
    {
        startPos = transform.position;
        renderer = GetComponent<SpriteRenderer>();
        ColorResponse();
    }

    private void Update()
    {
        Behaviours();
    }

    public void ChangeColor(ColorSpectrum.ColorSpec _spec)
    {
        _mySpec = _spec;
        renderer.color = _colorData.colorData.GetColor(_mySpec);
        ColorResponse();
    }

    void ColorResponse()
    {
        switch (_mySpec)
        {
            case ColorSpectrum.ColorSpec.White:
                transform.position = transform.position + Vector3.forward*2;
                break;
            default:
                transform.position = startPos;
                break;
        }
    }


    public void ChangeColor(Color _color)
    {
        renderer.color = _color;
    }

    virtual protected void Behaviours()
    {
        switch (_mySpec)
        {
            case ColorSpectrum.ColorSpec.Green:
                //origin.x + Mathf.Sin(Time.time * speed) * amount,
                //transform.localPosition.y, transform.localPosition.z);
                //transform.position = 
                break;
            default:
                break;
        }
    }
}
