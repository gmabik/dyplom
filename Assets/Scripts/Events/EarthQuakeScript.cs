using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EarthQuakeScript : EventAbstract
{
    [SerializeField] private float camShakeTime;

    [Range(1f, 10f)]
    [SerializeField] private float portalDisableTime;
    protected override void OnSpawn()
    {
        foreach (var portal in EventManager.Instance.portals)
        {
            StartCoroutine(portal.GetComponent<Teleport>().TeleportCooldown(portalDisableTime));
        }

        foreach (var cam in EventManager.Instance.cameras)
        {
            StartCoroutine(shakeCamera(cam.transform));
        }
    }

    private IEnumerator shakeCamera(Transform camera)
    {
        float a = camShakeTime;
        while (a > 0f)
        {
            float b = Random.Range(0.15f, 0.4f);

            camera.DOLocalMove(new(Random.Range(-3f, 3f), Random.Range(-3f, 3f), -65f), b);

            yield return new WaitForSeconds(b);
            a -= b;
        }
        camera.DOLocalMove(new(0f, 0f, -65f), 0.2f);
    }
}
