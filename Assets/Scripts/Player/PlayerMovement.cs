using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpForce = 5;
    [SerializeField] float speed = 5;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float radius = 0.3f;
    int jumpCount = 0;
    int maxJumps = 1;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform topCheck;
    [SerializeField] Transform groundCheck;
    CharacterController controller;
    Vector3 direction = Vector3.zero;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, radius, groundLayer);
        if (!isGrounded)
        {
            direction.y += gravity * Time.deltaTime;
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
        if (jumpCount > 0)
        {
            direction.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            jumpCount--;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        direction.x = ctx.ReadValue<float>() * speed;
    }
}
