using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    #region singleton
    public static EventManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null) Destroy(Instance);
        Instance = this;
    }
    #endregion

    [Range(1f, 30f)]
    [SerializeField] private float spawnTime;

    [SerializeField] private List<EventAbstract> totalEventsAmount;
    public List<Movement> players;
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

    public Movement GetRandomPlayer()
    => players[Random.Range(0, players.Count)];
}
