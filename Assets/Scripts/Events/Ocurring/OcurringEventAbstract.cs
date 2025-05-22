using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OcurringEventAbstract : MonoBehaviour
{
    protected Vector3 startPosition;
    protected Quaternion startRotation;

    protected Rigidbody2D _rb;
    protected SpriteRenderer _renderer;
    protected Collider2D _collider;

    protected bool isInUse;
    [SerializeField] protected float resetDelay;

    protected void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        isInUse = false;
        _rb = GetComponent<Rigidbody2D>();

        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();

        _rb.isKinematic = true;
    }

    protected void ShouldBeHidden(bool a)
    {
        _renderer.enabled = !a;
        _collider.enabled = !a;
        _rb.isKinematic = a;
    }

    protected private IEnumerator ResetEvent()
    {
        yield return new WaitForSeconds(resetDelay);

        transform.position = startPosition;
        transform.rotation = startRotation;
        _rb.velocity = Vector2.zero;
        _rb.angularVelocity = 0f;

        _renderer.enabled = true;
        _collider.enabled = true;

        isInUse = false;
    }
}
