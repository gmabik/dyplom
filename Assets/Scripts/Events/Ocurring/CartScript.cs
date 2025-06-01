using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartScript : OcurringEventAbstract
{
    private float timer;
    [SerializeField] private int damage;
    private new void Start()
    {
        base.Start();
        RerollTimer();
        StartCoroutine(Activate());
    }

    private IEnumerator Activate()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            isInUse = true;
            _rb.isKinematic = false;
            _rb.AddForce(transform.right * (transform.rotation.z > 0f? -100f : 100f));
            print(transform.right * (transform.rotation.z > 0f ? -100f : 100f));
            StartCoroutine(ResetEvent());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isInUse) return;

        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable entity))
            entity.GetDamage(damage);
    }

    private void RerollTimer()
        => timer = Random.Range(15f, 30f);
}
