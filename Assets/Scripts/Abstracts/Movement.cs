using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Movement : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] protected float speed;
    [SerializeField] protected float jumpPower;
    [SerializeField] protected bool isFacingRight;

    [SerializeField] protected Rigidbody2D rb;
    protected void MoveCharacter(float horizontal)
    {
        rb.velocity = new(horizontal * speed, rb.velocity.y);
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }

    protected void Jump()
    {
        rb.velocity = new(rb.velocity.x, jumpPower);
    }

    protected void FallDown()
    {
        rb.MovePosition((Vector2)transform.position + ((Vector2)transform.up * -1f * speed * Time.deltaTime));
    }
}
