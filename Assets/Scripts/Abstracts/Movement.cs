using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public int hp => default;
    public void GetDamage(int damage);
}

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Movement : MonoBehaviour, IDamageable
{
    public bool isGrounded;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float speed;

    [Header("Jumping")]
    public bool hasDoubleJump;
    [SerializeField] protected float jumpPower;

    protected bool canBeHit = true;
    public enum MainDirection
    {
        Right,
        Left
    }

    public enum SubDirection
    {
        Up,
        Down,
        Main
    }

    [Header("Rotating")]
    public MainDirection dirFacing;
    public SubDirection dirLookedAt;

    private Animator animator;

    [Space(10)]
    [SerializeReference] protected Vector3 scale;
    void Start()
    {
        canBeHit = true;
        EventManager.Instance.players.Add(this);
        rb = GetComponent<Rigidbody2D>();
        hasDoubleJump = true;
        scale = transform.localScale;
        animator = GetComponent<Animator>();
    }

    protected void MoveCharacter(float horizontal, float vertical)
    {
        rb.velocity = new(horizontal * speed, rb.velocity.y);
        ManageFacingDir(horizontal);
        ManageLookedAtDir(vertical);

        if (horizontal != 0) animator.SetBool("isWalking", true);
        else animator.SetBool("isWalking", false);
    }

    protected void ManageFacingDir(float horizontal)
    {
        if (dirFacing == MainDirection.Right && horizontal < 0f)
        {
            dirFacing = MainDirection.Left;
            scale.x *= -1f;
            transform.localScale = scale;
        }
        else if (dirFacing == MainDirection.Left && horizontal > 0f)
        {
            dirFacing = MainDirection.Right;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }

    protected void ManageLookedAtDir(float vertical)
    {
        if (dirLookedAt != SubDirection.Down && vertical < 0f)
        {
            dirLookedAt = SubDirection.Down;
        }
        else if (dirLookedAt != SubDirection.Up && vertical > 0f)
        {
            dirLookedAt = SubDirection.Up;
        }
        else if(dirLookedAt != SubDirection.Main && vertical == 0f)
        {
            dirLookedAt = SubDirection.Main;
        }
        
    }

    protected void Jump()
    {
        rb.velocity = new(rb.velocity.x, jumpPower);
        if(!isGrounded) hasDoubleJump = false;
    }

    protected void FallDown()
    {
        rb.MovePosition((Vector2)transform.position + ((Vector2)transform.up * -1f * speed * Time.deltaTime));
    }

    public abstract void GetDamage(int damage);

    public IEnumerator GainInvincibility(float time)
    {
        canBeHit = false;
        var a = speed;
        speed /= 2f;
        yield return new WaitForSeconds(time);
        canBeHit = true;
        speed = a;
    }
}
