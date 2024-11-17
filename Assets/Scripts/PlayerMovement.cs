using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : Movement
{
    private float horizontal;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.W) && isGrounded) Jump();

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f && !isGrounded)
        {
            rb.velocity = new(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(horizontal);
        //if(isGrounded == false) FallDown();
    }
}
