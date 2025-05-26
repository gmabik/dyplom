using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformBurningScript : MonoBehaviour
{
    [SerializeField] private Sprite burningPlatform;
    [SerializeField] private float totalTime;
    private List<Transform> children;
    private float delay;

    private void Start()
    {
        children = GetComponentsInChildren<Transform>().ToList();
        delay = totalTime / children.Count;
        StartCoroutine(burnPlatform());
    }

    private IEnumerator burnPlatform()
    {
        while (children.Count > 0)
        {
            yield return new WaitForSeconds(delay);
            var a = children[Random.Range(0, children.Count)];
            a.GetComponent<SpriteRenderer>().sprite = burningPlatform;
            a.AddComponent<GiveDamageOnTouch>().damage = 1;
            children.Remove(a);
        }
    }
}
