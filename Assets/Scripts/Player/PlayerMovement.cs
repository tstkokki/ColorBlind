using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

public class PlayerMovement : MonoBehaviour
{

    Vector3 startPos;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float speed = 5;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float radius = 0.3f;
    int jumpCount = 0;
    int maxJumps = 1;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform topCheck;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform groundCheck2;
    CharacterController controller;
    Vector3 direction = Vector3.zero;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded =
            Physics.CheckSphere(groundCheck.position, radius, groundLayer)
            || Physics.CheckSphere(groundCheck2.position, radius, groundLayer);
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
            if (jumpCount < maxJumps)
            {
                jumpCount = maxJumps;
            }
        }
        controller.Move(direction * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (jumpCount > 0 && ctx.ReadValue<float>() > 0)
        {
            direction.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            jumpCount--;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        direction.x = ctx.ReadValue<float>() * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Killzone"))
        {
            transform.position = startPos;
        }
    }
}
