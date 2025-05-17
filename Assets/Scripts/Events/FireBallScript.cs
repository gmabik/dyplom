using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : FlyDamageTrigger
{
    protected override void OnSpawn()
    {
        float x = EventManager.Instance.GetRandomPlayer().transform.position.x;
        float y = 25f;
        transform.position = new Vector3(x, y, -1f);

        dir = -Vector3.up;
    }
}
