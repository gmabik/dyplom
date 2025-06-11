using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public float teleportCooldown = 1f;
    [SerializeField] private bool canTeleport = true;
    private Sprite startSprite;
    private void Start()
    {
        startSprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTeleport && collision.CompareTag("Player"))
        {
            collision.transform.position = new(teleportTarget.position.x, teleportTarget.position.y, collision.transform.position.z);

            StartCoroutine(TeleportCooldown(teleportCooldown));

            Teleport otherPortal = teleportTarget.GetComponent<Teleport>();
            if (otherPortal != null)
            {
                otherPortal.StartCoroutine(otherPortal.TeleportCooldown(teleportCooldown));
            }
        }
    }

    public IEnumerator TeleportCooldown(float time)
    {
        GameObject particles = transform.GetComponentInChildren<ParticleSystem>().gameObject;
        particles.SetActive(false);
        canTeleport = false;
        yield return new WaitForSeconds(time);
        canTeleport = true;
        GetComponent<SpriteRenderer>().sprite = startSprite;
        GetComponent<Animator>().enabled = true;
        particles.SetActive(true);
    }
}
