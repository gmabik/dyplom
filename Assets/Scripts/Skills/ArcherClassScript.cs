using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherClassScript : ClassScript
{
    protected override void Skill()
    {
        var a = gameObject.GetComponent<Attack>().RangedAttack(false);

        var b = gameObject.GetComponent<Attack>().RangedAttack(false);
        b.transform.position = b.transform.position + new Vector3(0f, 0.2f, 0f);

        if(b.transform.eulerAngles.z > 0 && b.transform.eulerAngles.z < 180) 
            b.transform.eulerAngles = b.transform.eulerAngles + new Vector3(0f, 0f, 45f);
        else 
            b.transform.eulerAngles = b.transform.eulerAngles - new Vector3(0f, 0f, 45f);

        var c = gameObject.GetComponent<Attack>().RangedAttack(true);
        c.transform.position = c.transform.position + new Vector3(0f, -0.2f, 0f);

        if (c.transform.eulerAngles.z > 0 && c.transform.eulerAngles.z < 180) 
            c.transform.eulerAngles = c.transform.eulerAngles + new Vector3(0f, 0f, -45f);
        else
            c.transform.eulerAngles = c.transform.eulerAngles - new Vector3(0f, 0f, -45f);

        StartCoroutine(manageCollision(a, b, c));
    }

    private IEnumerator manageCollision(GameObject a, GameObject b, GameObject c)
    {
        a.GetComponent<Collider2D>().enabled = false;
        b.GetComponent<Collider2D>().enabled = false;
        c.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.05f);
        a.GetComponent<Collider2D>().enabled = true;
        b.GetComponent<Collider2D>().enabled = true;
        c.GetComponent<Collider2D>().enabled = true;
    }
}
