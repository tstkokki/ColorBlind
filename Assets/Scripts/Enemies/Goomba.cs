using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : ColorBehaviour
{
    public float jumpPower = 0.5f;
    Rigidbody goombaRB;

    bool hasTriggered = false;
    [SerializeField] LayerMask groundLayer;

    // Start is called before the first frame update
    override protected void Start()
    {
        goombaRB = GetComponent<Rigidbody>();
        base.Start();
    }

    protected override void ColorResponse()
    {
        base.ColorResponse();
        switch (_mySpec)
        {
            case ColorSpectrum.ColorSpec.Green:
                goombaRB.isKinematic = true;
                break;
            case ColorSpectrum.ColorSpec.Black:
                gameObject.tag = "Killzone";
                goombaRB.isKinematic = false;
                break;
            default:
                goombaRB.isKinematic = false;
                gameObject.tag = "Enemy";
                break;
        }
    }

    //called every late update
    protected override void Behaviours()
    {
        base.Behaviours();
        switch (_mySpec)
        {
            case ColorSpectrum.ColorSpec.Red:
                bool isGrounded = Physics.CheckSphere(transform.position, 1, groundLayer);
                if (isGrounded)
                {
                    goombaRB.AddForce(Vector3.up*10);
                }
                break;

            default:
                break;
        }

        
    }

}