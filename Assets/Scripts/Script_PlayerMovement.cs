using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_PlayerMovement : MonoBehaviour
{
    [SerializeField] bool usingController;
    [SerializeField] float moveSpeed = 10f;
    CharacterController controller;
    Vector2 movement;
    [SerializeField] Transform groundCheck;
    float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;
    Vector3 velocity;
    [SerializeField] bool isGrounded;

    private void Start()
    {
        controller = transform.GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (usingController)
        {
            float x = Input.GetAxisRaw("HorizontalController");
            float z = Input.GetAxisRaw("VerticalController");
            moveCharacter(x, z);


            if (Input.GetButtonDown("JumpController") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        else // using Keyboard
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            moveCharacter(x, z);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void moveCharacter(float x, float z)
    {
        Vector3 move = transform.right * x + transform.forward * z;
        move = Vector3.ClampMagnitude(move, moveSpeed);
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

}
