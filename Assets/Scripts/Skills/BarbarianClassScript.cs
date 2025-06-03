using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianClassScript : ClassScript
{
    [SerializeField] private float invincibleTime;
    protected override void Skill()
    {
        var movement = GetComponent<Movement>();
        StartCoroutine(movement.GainInvincibility(invincibleTime));
    }

    public override void GetBuff()
    {
        var a = gameObject.GetComponent<Movement>();
        a.StopCoroutine(a.Regen());
        a.StartCoroutine(a.Regen());
    }
}
