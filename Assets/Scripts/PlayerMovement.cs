using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    private CharacterController controller;
    private Vector3 direction;
    private Vector3 targetPosition;
    private int desiredLane = 0;
    [SerializeField] private float laneDistance = 4;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Debug.Log(gameObject.name);
    }

    private void Update()
    {
        direction.z = forwardSpeed;
        direction.y += gravity*Time.deltaTime;
        // Movement
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(desiredLane == 0) desiredLane ++;
            else if(desiredLane == 1) desiredLane--;
        }
        
        if(controller.isGrounded)
        {
            direction.y = -1;
            if(Input.GetKeyDown(KeyCode.Space)) Jump();
        }
        else direction.y += gravity * Time.deltaTime;

        // Future Position
        targetPosition = transform.position.z * transform.forward + 
            transform.position.y * transform.up;

        if(desiredLane == 0) targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 1) targetPosition += Vector3.right * laneDistance;
        else
        {
            if(desiredLane < 0)targetPosition += Vector3.left * laneDistance;
            else if(desiredLane > 1) targetPosition += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //controller.Move(direction * Time.deltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }
}
