using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageClassScript : ClassScript
{
    [SerializeField] private float tpDist;

    protected override void Skill()
    {
        var movement = gameObject.GetComponent<Movement>();

        Vector2 dir = movement.dirFacing == Movement.MainDirection.Left ? -gameObject.transform.right : gameObject.transform.right;
        if (movement.dirLookedAt != Movement.SubDirection.Main) dir = movement.dirLookedAt == Movement.SubDirection.Up ? gameObject.transform.up : -gameObject.transform.up;

        print(dir);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)dir/3, dir, tpDist );

        if (hit)
        {
            transform.position = Vector2.Lerp(transform.position, hit.point, 0.9f);
        }
        else transform.position += (Vector3)dir * tpDist;

    }
}
