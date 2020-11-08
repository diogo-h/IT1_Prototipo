using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    private CharacterController controller;
    private Animator anim;
    private Vector3 direction;
    private Vector3 targetPosition;
    private int desiredLane = 0;
    private float maxLane = 1.5f;
    private float minLane = -2.5f;
    [SerializeField] private float laneDistance = 4;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Debug.Log(gameObject.name);
    }

    private void Update()
    {
        direction.z = forwardSpeed;

        // Movement
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(desiredLane == 0) desiredLane ++;
            else if(desiredLane == 1) desiredLane--;
        }

        // Jumping
        if (controller.isGrounded)
        {
            direction.y = -1;

            Debug.Log("IsGrounded right now!");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        //else
        //{
        //    //Debug.Log("IsNotGrounded right now!");
        //    //direction.y += gravity * Time.deltaTime;
        //}

        // Future Position
        targetPosition = transform.position.z * transform.forward + 
            transform.position.y * transform.up;

        if(transform.position.x <= maxLane)
            if (desiredLane >= 1) targetPosition += Vector3.right * laneDistance;
        if (transform.position.x >= minLane)
            if (desiredLane <= 0) targetPosition += Vector3.left * laneDistance;
    
        direction.x = targetPosition.x * 4;

        controller.Move(direction * Time.deltaTime);
    }
    private void Jump()
    {
        Debug.Log("Reached JUMP()");
        direction.y = jumpForce;
    }
}