using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ClassScript>(out ClassScript script))
        {
            script.GetBuff();
            Destroy(gameObject);
        }
    }
}
