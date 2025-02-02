﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;            

    Vector3 movement;                   
    Animator anim;                      
    Rigidbody playerRigidbody;         
    int floorMask;                     
    float camRayLength = 100f;          

    void Awake()
    {
       
        floorMask = LayerMask.GetMask("Floor");

        
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
       
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

       
        Move(h, v);

      
        Turning();

        
        Animating(h, v);
    }

    void Move(float h, float v)
    {
       
        movement.Set(h, 0f, v);

        
        movement = movement.normalized * speed * Time.deltaTime;

       
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        //ray from the mouse on screen in the direction of the camera
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // RaycastHit variable to store information about what was hit by the ray
        RaycastHit floorHit;

        //  raycast and if it hits something on the floor
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit
            Vector3 playerToMouse = floorHit.point - transform.position;

           
            playerToMouse.y = 0f;

            // Create a quaternion  based on looking down the vector from the player to the mouse
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        // boolean that is true if either of the input axes is non-zero
        bool walking = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking
        anim.SetBool("IsWalking", walking);
    }
}