using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefClassScript : ClassScript
{
    protected override void Skill()
    {
        gameObject.GetComponent<Attack>().RangedAttack(false);
    }
}
