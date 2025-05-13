using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDamageTrigger : EventAbstract
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    private Vector3 dir;
    protected override void OnSpawn()
    {
        float x = 0;
        float y = 0;
        while(x == 0 && y == 0)
        {
            x = Random.Range(15f, 30f) * Random.Range(-1, 2);
            y = Random.Range(15f, 30f) * Random.Range(-1, 2);
        }
        transform.position = new Vector2(x, y);

        dir = EventManager.Instance.GetRandomPlayer().transform.position - transform.position;
        dir.Normalize();
        StartCoroutine(DespawnAfterTime());
    }

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
        else if (collision.transform.parent != null && collision.transform.parent.TryGetComponent<IDamageable>(out IDamageable hpScript2))
        {
            hpScript2.GetDamage(damage);
        }
    }

    private IEnumerator DespawnAfterTime()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
}
