using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileScript : MonoBehaviour
{
    public GameObject instigator;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == instigator || collision.transform.parent?.gameObject == instigator) return;

        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable hpScript))
        {
            hpScript.GetDamage(damage);
        }
        else if (collision.transform.parent != null && collision.transform.parent.TryGetComponent<IDamageable>(out IDamageable hpScript2))
        {
            hpScript2.GetDamage(damage);
        }

        Destroy(gameObject);
    }
}
