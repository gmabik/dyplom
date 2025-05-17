using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSwarmScript : FlyDamageTrigger
{
    protected override void OnSpawn()
    {
        float x = 0;
        float y = 0;
        while (x == 0 && y == 0)
        {
            x = Random.Range(15f, 30f) * Random.Range(-1, 2);
            y = Random.Range(15f, 30f) * Random.Range(-1, 2);
        }
        transform.position = new Vector2(x, y);

        dir = EventManager.Instance.GetRandomPlayer().transform.position - transform.position;
        dir.Normalize();
        
    }
}
