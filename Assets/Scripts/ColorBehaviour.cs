using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBehaviour : MonoBehaviour
{
    [SerializeField] protected ColorData_SO _colorData;
    protected SpriteRenderer renderer;
    [SerializeField] GameEvent RespawnPlayer;
    [SerializeField] protected ColorSpectrum.ColorSpec _mySpec;
    [SerializeField] Sounds_SO _sounds;
    public float movementX;
    public float movementY;

    protected Vector3 startPos;
    protected float time = 0;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        startPos = transform.position;
        renderer = GetComponent<SpriteRenderer>();
        ChangeColor(_mySpec);
    }

    virtual protected void LateUpdate()
    {
        Behaviours();
    }

    public void ChangeColor(ColorSpectrum.ColorSpec _spec)
    {
        if (_mySpec != ColorSpectrum.ColorSpec.Black)
        {

            switch (_mySpec)
            {
                case ColorSpectrum.ColorSpec.Red:
                    movementY = 0;
                    break;

                case ColorSpectrum.ColorSpec.Green:
                    movementX = 0;
                    break;

                default:
                    break;
            }

            _mySpec = _spec;
            Color col =
            _colorData.colorData.GetColor(_mySpec);
            if (col != null)
            {
                renderer.color = col;
                ColorResponse();
            }
        }
    }

    public void ChangeColor(Color _color)
    {
        renderer.color = _color;
        ColorResponse();
    }

    virtual protected void ColorResponse()
    {
        switch (_mySpec)
        {

            //when object is white, shifts it away on the Z axis
            case ColorSpectrum.ColorSpec.White:
                transform.position = new Vector3(transform.position.x, transform.position.y, startPos.z + 2);
                break;
            default:
                transform.position = new Vector3(transform.position.x, transform.position.y, startPos.z);
                break;
        }
    }


    virtual protected void Behaviours()
    {
        switch (_mySpec)
        {
            case ColorSpectrum.ColorSpec.Green:
                //origin.x + Mathf.Sin(Time.time * speed) * amount,
                //transform.localPosition.y, transform.localPosition.z);
                time += Time.deltaTime;
                movementX = (startPos.x + 1 * Mathf.Sin(time * 1.5f) * 2) - transform.position.x;
                transform.position = new Vector3(startPos.x + 1 * Mathf.Sin(time * 1.5f) * 2, transform.position.y, 0);
                break;
            case ColorSpectrum.ColorSpec.Red:
                time += Time.deltaTime;
                movementY = (startPos.y + 1 * Mathf.Sin(time * 1.5f) * 2) - transform.position.y;
                transform.position = new Vector3(transform.position.x, startPos.y + 1 * Mathf.Sin(time * 1.5f) * 2, 0);
                break;
            default:
                break;
        }
    }


    protected void OnTriggerEnter(Collider other)
    {
        if (RespawnPlayer != null)
        {

            if (_mySpec == ColorSpectrum.ColorSpec.Black && other.gameObject.CompareTag("Player"))
            {
                _sounds.PlayFromList(5);
                RespawnPlayer.Raise();
            }
        }
    }
}
