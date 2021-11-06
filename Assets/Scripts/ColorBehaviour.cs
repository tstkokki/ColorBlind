using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBehaviour : MonoBehaviour
{
    [SerializeField] protected ColorData_SO _colorData;
    protected SpriteRenderer renderer;

    [SerializeField] protected ColorSpectrum.ColorSpec _mySpec;

    Vector3 startPos;
    float time = 0;
    // Start is called before the first frame update
    protected void Start()
    {
        startPos = transform.position;
        renderer = GetComponent<SpriteRenderer>();
        ChangeColor(_mySpec);
    }

    private void LateUpdate()
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
                transform.position = startPos + Vector3.forward*2;
                break;
            default:
                transform.position = new Vector3( transform.position.x, transform.position.y, startPos.z);
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
                time += Time.deltaTime;
                transform.position = startPos + Vector3.right * Mathf.Sin(time * 1.5f) * 2;
                break;
            default:
                break;
        }
    }
}
