using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamageOnTouch : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable idmg))
        {
            idmg.GetDamage(damage);
        }
    }
}
