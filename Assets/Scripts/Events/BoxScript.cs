using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BoxScript : MonoBehaviour, IDamageable
{
    private SpriteRenderer sr;
    private Collider2D _collider;

    private Vector3 spawnPos;
    [SerializeField] private float respawnTime;

    [SerializeField] private int explosionDamage;
    private bool isExplosive;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        spawnPos = transform.position;
        RerollExplosiveness();
    }

    public void GetDamage(int damage)
    {
        if (isExplosive)
        {
            Explode();
        }
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        sr.enabled = false;
        _collider.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        sr.enabled = true;
        _collider.enabled = true;
        transform.position = spawnPos;
        RerollExplosiveness();
    }

    private void RerollExplosiveness()
        => isExplosive = Random.Range(0, 4) == 3 ? true : false;
    private void Explode()
    {
        var hits = Physics2D.BoxCastAll(transform.position, new(0.4f, 0.4f), 0f, transform.forward);
        if (hits.Count() == 0) return;

        foreach (var hit in hits)
        {
            if (hit.collider.gameObject != gameObject && hit.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.GetDamage(explosionDamage);
            }
        }
    }
}
