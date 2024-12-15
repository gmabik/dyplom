using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.GetComponent<Movement>().isGrounded = true;
        transform.parent.GetComponent<Movement>().hasDoubleJump = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.GetComponent<Movement>().isGrounded = false;
    }
}
