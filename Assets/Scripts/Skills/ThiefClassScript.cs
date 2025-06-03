using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefClassScript : ClassScript
{
    protected override void Skill()
    {
        gameObject.GetComponent<Attack>().RangedAttack(false);
    }

    public override void GetBuff()
    {
        var a = gameObject.GetComponent<Movement>();
        a.StopCoroutine(a.BuffSpeed());
        a.StartCoroutine(a.BuffSpeed());
    }
}
