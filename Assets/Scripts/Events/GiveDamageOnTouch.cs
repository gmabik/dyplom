using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamageOnTouch : MonoBehaviour
{
    public int damage = 1;

    public int dmgCD;
    public bool isOnCD;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isOnCD) return;

        if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable idmg))
        {
            idmg.GetDamage(damage);
            StartCoroutine(Cooldown());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isOnCD) return;

        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable idmg))
        {
            idmg.GetDamage(damage);
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        isOnCD = true;
        yield return new WaitForSeconds(dmgCD);
        isOnCD = false;
    }
}
