using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour, IDamageable
{
    [SerializeField] private Color unattacked;
    [SerializeField] private Color attacked;

    private void Start()
    {
        GetComponent<Renderer>().material.color = unattacked;
    }

    public void GetDamage(int damage)
    {
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = attacked;
        yield return new WaitForSeconds(1);
        GetComponent<Renderer>().material.color = unattacked;
    }
}
