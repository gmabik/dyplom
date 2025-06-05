using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(AudioSource))]
public class PlayerAttack : Attack
{
    private int playerNum;
    private AudioSource audioSource;

    [Header("Attack Sound")]
    public AudioClip attackSound;

    private void Start()
    {
        playerNum = gameObject.GetComponent<PlayerMovement>().playerNum;
        movement = gameObject.GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire" + playerNum))
        {
            if (attackSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(attackSound);
            }

            switch (attackType)
            {
                case AttackType.Ranged:
                    RangedAttack(true);
                    break;
                case AttackType.Melee:
                    MeleeAttack(true);
                    break;
            }
        }
    }
}
