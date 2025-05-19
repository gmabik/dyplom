using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClassScript : MonoBehaviour
{
    private int playerNum;
    private void Start()
    {
        playerNum = gameObject.GetComponent<PlayerMovement>().playerNum;
        currentCD = 0f;
    }

    [SerializeField] protected float skillCD;
    private float currentCD;

    private void Update()
    {
        currentCD -= Time.deltaTime;
        if (Input.GetButtonDown("Skill" + playerNum) && currentCD < 0f)
        {
            currentCD = skillCD;
            Skill();
        }
    }

    protected abstract void Skill();
}
