using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventAbstract : MonoBehaviour
{
    void Start()
    {
        OnSpawn();
        StartCoroutine(DespawnAfterTime());
    }

    protected abstract void OnSpawn();

    protected IEnumerator DespawnAfterTime()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
}
