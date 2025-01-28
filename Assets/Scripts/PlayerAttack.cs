using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAttack : MonoBehaviour
{
    private int playerNum;
    [SerializeField] private GameObject projectilePrefab;
    private void Start()
    {
        playerNum = gameObject.GetComponent<PlayerMovement>().playerNum;
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire" + playerNum))
        {
            Attack();
        }
    }

    private void Attack()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        var a = transform.position + transform.right;
        a.z = -1f;
        projectile.transform.position = a;
    }
}
