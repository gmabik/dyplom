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
    [SerializeField] protected MainDirection dirFacing;
    [SerializeField] protected SubDirection dirLookedAt;
    [SerializeField] protected GameObject weapon;

    [Space(10)]
    [SerializeReference] protected Vector3 scale;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hasDoubleJump = true;
        scale = transform.localScale;
    }

    protected void MoveCharacter(float horizontal, float vertical)
    {
        rb.velocity = new(horizontal * speed, rb.velocity.y);
        ManageFacingDir(horizontal);
        ManageLookedAtDir(vertical);
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
            MoveWeapon(dirLookedAt);
        }
        else if (dirLookedAt != SubDirection.Up && vertical > 0f)
        {
            dirLookedAt = SubDirection.Up;
            MoveWeapon(dirLookedAt);
        }
        else if(dirLookedAt != SubDirection.Main && vertical == 0f)
        {
            dirLookedAt = SubDirection.Main;
            MoveWeapon(dirLookedAt);
        }
        
    }

    protected void MoveWeapon(SubDirection dir)
    {
        switch (dir)
        {
            case SubDirection.Up:
                weapon.transform.localPosition = new(0f, 1.1f, 0f);
                weapon.transform.localEulerAngles = new(0f, 0f, 120f);
                break;
            case SubDirection.Down:
                weapon.transform.localPosition = new(0f, -1.1f, 0f);
                weapon.transform.localEulerAngles = new(0f, 0f, -60f);
                break;
            default:
                weapon.transform.localPosition = new(0.6f, 0f, 0f);
                weapon.transform.localEulerAngles = new(0f, 0f, 30f);
                break;
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
}
