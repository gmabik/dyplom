using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int damage;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = -transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable hpScript))
        {
            hpScript.GetDamage(damage);
        }
        else if (collision.transform.parent.TryGetComponent<IDamageable>(out IDamageable hpScript2))
        {
            hpScript2.GetDamage(damage);
        }
        Destroy(gameObject);
    }
}
