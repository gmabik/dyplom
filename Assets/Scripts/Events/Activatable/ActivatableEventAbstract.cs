using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivatableEventAbstract : MonoBehaviour, IDamageable
{
    public void GetDamage(int dmg)
    {
        Activate();
    }

    protected abstract void Activate();
}
