using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kolec : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody2D rb;
    private bool isFalling = false;
    private bool isResetting = false;

    [SerializeField] private float resetDelay = 10f;
    [SerializeField] private string groundTag = "Ground";

    private SpriteRenderer spriteRenderer;
    private Collider2D spikeCollider;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spikeCollider = GetComponent<Collider2D>();

        rb.isKinematic = true; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isFalling)
        {
            isFalling = true;
            rb.isKinematic = false; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFalling && collision.collider.CompareTag(groundTag))
        {
            HideSpike();
            StartCoroutine(ResetKolec());
        }
    }

    private void HideSpike()
    {
        spriteRenderer.enabled = false;
        spikeCollider.enabled = false;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }

    private IEnumerator ResetKolec()
    {
        isResetting = true;
        yield return new WaitForSeconds(resetDelay);

        transform.position = startPosition;
        transform.rotation = startRotation;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        spriteRenderer.enabled = true;
        spikeCollider.enabled = true;

        isFalling = false;
        isResetting = false;
    }
}
