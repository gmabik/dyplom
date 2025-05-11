using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Range(1f, 30f)]
    [SerializeField] private float spawnTime;

    [SerializeField] private List<EventAbstract> totalEventsAmount;
    void Start()
    {
        StartCoroutine(spawnEvents());
    }

    private IEnumerator spawnEvents()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            int i = Random.Range(0, totalEventsAmount.Count - 1);
            Instantiate(totalEventsAmount[i]);
        }
    }
}
