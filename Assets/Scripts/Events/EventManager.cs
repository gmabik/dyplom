using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [HideInInspector] public List<Movement> players;
    [HideInInspector] public List<Camera> cameras;

    public List<Teleport> portals;
    void Start()
    {
        StartCoroutine(spawnEvents());

        cameras.AddRange(Camera.allCameras);
    }

    private IEnumerator spawnEvents()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            int i = Random.Range(0, totalEventsAmount.Count);
            Instantiate(totalEventsAmount[i]);
        }
    }

    public Movement GetRandomPlayer()
    => players[Random.Range(0, players.Count)];
}
