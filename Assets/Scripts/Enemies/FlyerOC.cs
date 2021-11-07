using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerOC : ColorBehaviour
{
    public float jumpPower = 0.5f;
    Rigidbody goombaRB;
    float time2 = 0f;
    private bool isJumping = false;
    Vector3 startPos2;

    string baseTag;

    bool hasTriggered = false;
    bool hasTriggered2 = false;

    public GameObject player;

    [SerializeField] GameObject target;
    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
        goombaRB = GetComponent<Rigidbody>();
        startPos2 = transform.position;
        player = GameObject.FindWithTag("Player");
        baseTag = gameObject.tag;
    }

    

    protected override void Behaviours()
    {
        //base.Behaviours();
        switch (_mySpec)
        {
            case ColorSpectrum.ColorSpec.Green:
                gameObject.tag = baseTag;
                Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), false);
                hasTriggered2 = false;
                if (!hasTriggered)
                {
                    hasTriggered = true;
                    startPos = transform.position;
                }
                time += Time.deltaTime;
                transform.position = startPos + Vector3.right * Mathf.Sin(time * 1.5f) * 2;

                time2 = 0f;
                break;

            case ColorSpectrum.ColorSpec.Red:
                gameObject.tag = baseTag;
                Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), false);
                hasTriggered = false;
                goombaRB.useGravity = false;

                if (!hasTriggered2)
                {
                    hasTriggered2 = true;
                    startPos2 = transform.position;
                }
                time2 += Time.deltaTime;
                transform.position = startPos2 + Vector3.up * Mathf.Sin(time2 * 1.5f) * 2;

                time = 0f;
                break;

            case ColorSpectrum.ColorSpec.Blue:
                gameObject.tag = baseTag;
                hasTriggered = false;
                hasTriggered2 = false;
                Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), false);
                goombaRB.velocity = new Vector3(0, 0, 0);
                goombaRB.useGravity = false;
                transform.position = transform.position;
                time = 0f;
                time2 = 0f;
                break;

            case ColorSpectrum.ColorSpec.White:
                gameObject.tag = baseTag;
                hasTriggered2 = false;
                hasTriggered = false;
                goombaRB.useGravity = false;
                Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), true);
                time = 0f;
                time2 = 0f;
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