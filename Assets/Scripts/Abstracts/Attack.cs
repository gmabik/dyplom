using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public abstract class Attack : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    protected Movement movement;
    [SerializeField] protected int meleeDmg;

    public enum AttackType
    {
        Ranged,
        Melee
    }

    [SerializeField] protected AttackType attackType;
    public GameObject RangedAttack()
    {
        DoAnim();

        GameObject projectile = Instantiate(projectilePrefab);

        var pos = transform.position;
        var rot = projectile.transform.eulerAngles;
        pos.z = -1f;

        if (movement.dirLookedAt == Movement.SubDirection.Main)
        {
            pos += new Vector3(0.2f * transform.localScale.x, 0f, 0f);
           
            rot.z = transform.localScale.x >= 0 ? rot.z : -rot.z;
        }
        else
        {
            pos += new Vector3(0f, 0.2f * transform.localScale.y * (movement.dirLookedAt == Movement.SubDirection.Up ? 1f : -1f), 0f);

            rot.z = movement.dirLookedAt == Movement.SubDirection.Up ? 180f : 0f;
        }

        projectile.transform.position = pos;
        projectile.transform.eulerAngles = rot;

        projectile.GetComponent<ProjectileScript>().instigator = gameObject;

        return projectile;
    }

    public void MeleeAttack()
    {
        DoAnim();

        var pos = transform.position;

        if (movement.dirLookedAt == Movement.SubDirection.Main)
        {
            pos += new Vector3(0.3f * transform.localScale.x, 0f, 0f);
            print(pos.x);
        }
        else
        {
            pos += new Vector3(0f, 0.5f * transform.localScale.y * (movement.dirLookedAt == Movement.SubDirection.Up ? 1f : -1f), 0f);
        }
        
        var hits = Physics2D.BoxCastAll(pos, new(0.4f, 0.4f), 0f, transform.forward);
        if (hits.Count() == 0) return;

        foreach (var hit in hits)
        {
            if (hit.collider.gameObject != gameObject && hit.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.GetDamage(meleeDmg);
            }
        }
    }

    private void DoAnim()
    {
        gameObject.GetComponent<Animator>().SetTrigger("attack");
    }
}
