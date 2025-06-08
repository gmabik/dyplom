using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxScript : MonoBehaviour, IDamageable
{
    private SpriteRenderer sr;
    private Collider2D _collider;
    private Rigidbody2D rb;

    private Vector3 spawnPos;
    [SerializeField] private float respawnTime;

    [SerializeField] private int explosionDamage;
    private bool isExplosive;

    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject destroyEffect;

    private GameObject spawnedEffect;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;
        RerollExplosiveness();
    }

    public void GetDamage(int damage)
    {
        StartCoroutine(Respawn());

        if (isExplosive)
        {
            Explode();
            spawnedEffect = SpawnEffect(explosionEffect);
        }
        else spawnedEffect = SpawnEffect(destroyEffect);
    }

    private IEnumerator Respawn()
    {
        rb.isKinematic = true;
        sr.enabled = false;
        _collider.enabled = false;
        yield return new WaitForSeconds(respawnTime - 0.5f);
        sr.enabled = true;
        _collider.enabled = true;
        rb.isKinematic = false;
        transform.position = spawnPos;
        RerollExplosiveness();
    }

    private void RerollExplosiveness()
        => isExplosive = Random.Range(0, 4) == 3;

    private void Explode()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, new(0.5f, 0.5f), 0f, transform.up);
        if (hits.Count() == 0) return;

        foreach (var hit in hits)
        {
            if (hit.collider.gameObject != gameObject && hit.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.GetDamage(explosionDamage);
            }
        }
    }

    private GameObject SpawnEffect(GameObject effect)
    {
        var a = Instantiate(effect, transform);
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = Vector3.one * 35f;
        return a;
    }
}
