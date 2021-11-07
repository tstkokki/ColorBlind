using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] VectorThree_SO startPos;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float speed = 5;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float radius = 0.3f;
    //int jumpCount = 0;
    //int maxJumps = 1;
    [SerializeField] Animator anim;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask enemyLayer;

    [SerializeField] Transform topCheck;
    [SerializeField] Transform groundCheck;
    //[SerializeField] Transform groundCheck2;
    CharacterController controller;
    Vector3 direction = Vector3.zero;
    bool isGrounded;
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] ParticleSystem deathSplat;

    private AudioSource audioS;
    public AudioClip jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        startPos.Set(transform.position);
        controller = GetComponent<CharacterController>();
        audioS = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        //check if either foot is touching the ground
        isGrounded =
            Physics.CheckSphere(groundCheck.position, radius, groundLayer)
            || Physics.CheckSphere(groundCheck.position, radius, enemyLayer);

        anim.SetBool("Grounded", isGrounded);

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
            
            //if (jumpCount < maxJumps)
            //{
            //    jumpCount = maxJumps;
            //}
        }
        if (direction.x < 0.1 && direction.x > -0.1 || !isGrounded)
        {
            anim.SetBool("Walking", false);
        }
        else
        {
            anim.SetBool("Walking", true);
        }
        if(direction.x > 0 || direction.x < 0 || direction.y > 0 || direction.y < 0)
            controller.Move(direction * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        //if player is grounded and input is performed
        if (isGrounded && ctx.performed)
        {
            direction.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            anim.SetBool("Grounded", false);
            audioS.PlayOneShot(jumpSound);
            //jumpCount--;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        direction.x = ctx.ReadValue<float>() * speed;
        if(direction.x > 0 && renderer.flipX)
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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.name);
    }
}
