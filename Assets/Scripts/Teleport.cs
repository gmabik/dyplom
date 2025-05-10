using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public float teleportCooldown = 1f;
    private bool canTeleport = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTeleport && collision.CompareTag("Player"))
        {
            collision.transform.position = teleportTarget.position;

            StartCoroutine(TeleportCooldown());

            Teleport otherPortal = teleportTarget.GetComponent<Teleport>();
            if (otherPortal != null)
            {
                otherPortal.StartCoroutine(otherPortal.TeleportCooldown());
            }
        }
    }

    public IEnumerator TeleportCooldown()
    {
        canTeleport = false;
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }
}
