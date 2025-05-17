using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlyDamageTrigger : EventAbstract
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    protected Vector3 dir;
    

    private void FixedUpdate()
    {
        transform.position += dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable hpScript))
        {
            hpScript.GetDamage(damage);
        }
        //else if (collision.transform.parent != null && collision.transform.parent.TryGetComponent<IDamageable>(out IDamageable hpScript2))
        //{
        //    hpScript2.GetDamage(damage);
        //}
    }
}
