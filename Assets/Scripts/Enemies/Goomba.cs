using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : ColorBehaviour
{
    public float jumpPower = 0.5f;
    Rigidbody goombaRB;
    float time = 0f;
    private bool isJumping = false;
    Vector3 startPos;

    bool hasTriggered = false;

    public GameObject player;

    [SerializeField] GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        goombaRB = GetComponent<Rigidbody>();
        startPos = transform.position;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //goombaRB.velocity = new Vector2(speed, goombaRB.velocity.y);

        
    }

    protected override void Behaviours()
    {
        //base.Behaviours();
        switch (_mySpec)
        {
            case ColorSpectrum.ColorSpec.Green:
                Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), false);
                if (!hasTriggered)
                {
                    hasTriggered = true;
                    startPos = transform.position;
                }                           
                time += Time.deltaTime;
                transform.position = startPos + Vector3.right * Mathf.Sin(time * 1.5f) * 2;
                break;

            case ColorSpectrum.ColorSpec.Red:
                Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), false);
                hasTriggered = false;
                goombaRB.useGravity = true;

                if (goombaRB.velocity.magnitude > 0)
                {
                    isJumping = true;
                }
                else
                {
                    isJumping = false;
                }
                if(!isJumping)
                {
                    goombaRB.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
                }
                time = 0f;
                break;

            case ColorSpectrum.ColorSpec.Blue:
                hasTriggered = false;
                Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), false);
                goombaRB.velocity = new Vector3(0, 0, 0);
                goombaRB.useGravity = false;
                transform.position = transform.position;
                time = 0f;
                break;

            case ColorSpectrum.ColorSpec.White:
                hasTriggered = false;
                goombaRB.useGravity = true;
                Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), true);
                time = 0f;
                break;

            case ColorSpectrum.ColorSpec.Black:
                Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), false);
                gameObject.tag = "Killzone";


                break;

            default:
                break;
        }

    }

}