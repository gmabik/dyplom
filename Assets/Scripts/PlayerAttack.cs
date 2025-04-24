using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAttack : Attack
{
    private int playerNum;
    private void Start()
    {
        playerNum = gameObject.GetComponent<PlayerMovement>().playerNum;
        movement = gameObject.GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire" + playerNum))
        {
            switch (attackType)
            {
                case AttackType.Ranged:
                    RangedAttack();
                    break;
                case AttackType.Melee:
                    MeleeAttack();
                    break;
            }
            
        }
    }
}
