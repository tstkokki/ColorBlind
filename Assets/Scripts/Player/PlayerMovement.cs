using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UniRx;
using System;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] VectorThree_SO startPos;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float speed = 5;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float radius = 0.3f;
    int jumpCount = 0;
    int maxJumps = 1;
    [SerializeField] Animator anim;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask enemyLayer;
    
    [SerializeField] Transform topCheck;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform groundCheck2;
    CharacterController controller;
    Vector3 direction = Vector3.zero;
    bool isGrounded;
    bool animIsGrounded;
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] ParticleSystem deathSplat;
    [SerializeField] Sounds_SO _sounds;



    // Start is called before the first frame update
    void Start()
    {
        startPos.Set(transform.position);
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        //check if either foot is touching the ground
        isGrounded =
            Physics.CheckSphere(groundCheck.position, radius, groundLayer)
            || Physics.CheckSphere(groundCheck.position, radius, enemyLayer);

        animIsGrounded =
            Physics.CheckSphere(groundCheck2.position, radius, groundLayer)
            || Physics.CheckSphere(groundCheck2.position, radius, enemyLayer);

        anim.SetBool("Grounded", animIsGrounded);

        //if player is in the air, apply gravity
        if (!isGrounded)
        {
            direction.y += gravity * 1.5f * Time.deltaTime;
            direction.y = Mathf.Max(direction.y, -10);
        }
        else
        {

            if (direction.y < 0)
            {
                direction.y = 0;
            }

            if (jumpCount < maxJumps && direction.y <= 0.1f)
            {
                jumpCount = maxJumps;
            }
        }
        
        if(direction.x > 0 || direction.x < 0 || direction.y > 0 || direction.y < 0)
            controller.Move(direction * Time.deltaTime);
    }

    void LateUpdate()
    {
        if (animIsGrounded)
        {
            try
            {
                Vector3 outside = Vector3.zero;
                Collider coll = Physics.OverlapSphere(groundCheck2.position, radius, groundLayer)[0];
                if (coll != null)
                {
                    outside.y = coll.gameObject.GetComponent<ColorBehaviour>().movementY;
                    outside.x = coll.gameObject.GetComponent<ColorBehaviour>().movementX;
                }
                if (outside.x > 0 || outside.x < 0 || outside.y > 0 || outside.y < 0)
                    controller.Move(outside);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        //if player is grounded and input is performed
        if (ctx.performed && jumpCount > 0)
        {
            direction.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            anim.SetBool("Grounded", false);
            _sounds.PlayFromList(1);

            jumpCount--;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        direction.x = ctx.ReadValue<float>() * speed;
        if (direction.x < 0.1 && direction.x > -0.1 || !isGrounded)
        {
            anim.SetBool("Walking", false);
        }
        else
        {
            anim.SetBool("Walking", true);
        }
        if (direction.x > 0 && renderer.flipX)
        {
            renderer.flipX = false;
        }
        if(direction.x < 0 && !renderer.flipX)
        {
            renderer.flipX = true;
        }
    }


    public void Respawn()
    {

        Instantiate(deathSplat, transform.position, transform.rotation);
        direction = Vector3.zero;
        controller.enabled = false;
        transform.position = startPos.Get() + Vector3.up;
        controller.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Killzone") || other.gameObject.CompareTag("Enemy"))
        {
            Respawn();
        }
    }

}
