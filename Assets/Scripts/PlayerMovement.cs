using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : Movement
{
    private float horizontal;
    private float vertical;
    public int playerNum;
    [SerializeField] private Slider hpSlider;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal" + playerNum);
        vertical = Input.GetAxisRaw("Vertical" + playerNum);

        if (Input.GetAxisRaw("Jump" + playerNum) > 0 && (isGrounded || hasDoubleJump)) Jump();

        if (Input.GetAxisRaw("Jump" + playerNum) == 0 && rb.velocity.y > 0f && !isGrounded)
        {
            rb.velocity = new(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.K)) GetDamage(1);
    }

    private void FixedUpdate()
    {
        MoveCharacter(horizontal, vertical);
        //if(isGrounded == false) FallDown();
    }

    public override void GetDamage(int damage)
    {
        if (!canBeHit) return;
        hp -= damage;
        hpSlider.value = hp;

        StopCoroutine(BecomeRedWhenDamaged());
        StartCoroutine(BecomeRedWhenDamaged());
    }
}
