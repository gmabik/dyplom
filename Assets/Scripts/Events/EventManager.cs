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

    [Header("Events")]
    [Range(1f, 30f)]
    [SerializeField] private float spawnTime;

    [SerializeField] private List<EventAbstract> events;
    [HideInInspector] public List<Movement> players;
    [HideInInspector] public List<Camera> cameras;

    public List<Teleport> portals;

    [SerializeField] private GameObject blackout;

    [Header("Buffs")]
    [SerializeField] private GameObject buffPrefab;
    [SerializeField] private List<Transform> buffSpawns;
    void Start()
    {
        StartCoroutine(SpawnEvents());

        cameras.AddRange(Camera.allCameras);

        blackout.SetActive(false);
        StartCoroutine(Blackout());

        StartCoroutine(SpawnBuff());
    }

    private IEnumerator SpawnEvents()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            int i = Random.Range(0, events.Count);
            Instantiate(events[i]);
        }
    }

    public Movement GetRandomPlayer()
    => players[Random.Range(0, players.Count)];

    private IEnumerator Blackout()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10f, 20f));
            blackout.SetActive(true);
            yield return new WaitForSeconds(1f);
            blackout.SetActive(false);
        }
    }

    private IEnumerator SpawnBuff()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10f, 20f));
            var a = Instantiate(buffPrefab);
            a.transform.position = buffSpawns[Random.Range(0, buffSpawns.Count)].position;
        }
    }
}
