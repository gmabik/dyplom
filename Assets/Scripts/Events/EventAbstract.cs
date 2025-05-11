using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventAbstract : MonoBehaviour
{
    void Start()
    {
        OnSpawn();
    }

    protected abstract void OnSpawn();
}
