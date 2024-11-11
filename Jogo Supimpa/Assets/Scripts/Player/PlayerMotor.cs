using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isgrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;

    public float crouchTimer = 0;

    bool disabled;

    public bool lerpCrouch, crouching, sprinting;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Guard.OnGuardHasSpottedPlayer += Disable;
    }

    // Update is called once per frame
    void Update()
    {
        
        isgrounded = controller.isGrounded;
        if (lerpCrouch)
        {

            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
            {
                controller.height = Mathf.Lerp(controller.height, 1, p);
            }
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2, p);

            }
            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }

        }

    }
    //receive the inputs for our InputManager.cs and apply them to our character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        if (!disabled)
        {
           controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        }
        
        playerVelocity.y += gravity * Time.deltaTime;
        if (isgrounded && playerVelocity.y < 0) {

            playerVelocity.y = -2f;

        }
        controller.Move(playerVelocity * Time.deltaTime);
       
    }

    private void Disable()
    {
        disabled = true;
    }

    public void Jump()
    {

        if (isgrounded)
        {

            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);

        }
    }
    public void Crouch() {

        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;

    }
    public void Sprint()
    {

        sprinting = !sprinting;
        if (sprinting)
        {
            speed = 8;
        }
        else
        {
            speed = 5;
        }
    }

    private void OnDestroy()
    {
        Guard.OnGuardHasSpottedPlayer -= Disable;
    }
}
