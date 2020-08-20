
/*
 * Owen O' Dea
 * 
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public CharacterController controller;
    // Sets the player movment and the gravity.
    public float speed = 15.0f;
    public float gravity = -9.81f;
    //gets the location of groundcheck
    public Transform groundCheck;
    //sets the distance the player wants to stay away from the ground
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isOnGround;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checks to see if the player is on the ground
        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // If the player is not o the ground the player is moved down on the y axes. 
        if (isOnGround && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Takes input and moves the player 
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //Moves the player by time instead of frames.  
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}