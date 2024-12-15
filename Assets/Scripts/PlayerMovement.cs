using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : Movement
{
    private float horizontal;
    private float vertical;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || hasDoubleJump)) Jump();

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f && !isGrounded)
        {
            rb.velocity = new(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(horizontal, vertical);
        //if(isGrounded == false) FallDown();
    }
}
