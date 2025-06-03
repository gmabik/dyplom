using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : OcurringEventAbstract
{
    [SerializeField] private int damage = 1;
    private bool isInvincible = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isInUse)
        {
            isInUse = true;
            _rb.isKinematic = false;
            StartCoroutine(GainInvincibility());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isInUse) return;

        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable entity))
            entity.GetDamage(damage);

        if (!isInvincible)
        {
            ShouldBeHidden(true);
            StartCoroutine(ResetEvent());
        }
    }

    public IEnumerator GainInvincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(0.3f);
        isInvincible = false;
    }
}
