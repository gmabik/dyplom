using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public float teleportCooldown = 1f;
    [SerializeField] private bool canTeleport = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTeleport && collision.CompareTag("Player"))
        {
            collision.transform.position = teleportTarget.position;

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
        canTeleport = false;
        yield return new WaitForSeconds(time);
        canTeleport = true;
    }
}
