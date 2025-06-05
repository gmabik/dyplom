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

        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)dir/3, dir, tpDist );

        if (hit)
        {
            transform.position = Vector2.Lerp(transform.position, hit.point, 0.9f);
        }
        else transform.position += (Vector3)dir * tpDist;
        transform.position = new(transform.position.x, transform.position.y, -1f);
    }

    public override void GetBuff()
    {
        StopCoroutine(LowGravity());
        StartCoroutine(LowGravity());
    }

    private IEnumerator LowGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale /= 2;
        yield return new WaitForSeconds(5f);
        GetComponent<Rigidbody2D>().gravityScale *= 2;
    }
}
