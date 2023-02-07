using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    #region Params
    public GameObject spawnPrefab;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private bool autoSpawn;
    [SerializeField]
    [Range(0,20)]
    private int maxSpawnCount=10;

    private int spawnCount;
    private float lastSpawnTime;

    #endregion
    #region MyMethods
    private void SpawnClock()
    {
        if(Time.time>lastSpawnTime+spawnRate)
        {
            Spawn();
            lastSpawnTime = Time.time;
        }
    }
    public void Spawn()
    {
        if (maxSpawnCount <= spawnCount)
        {
            Debug.Log("Max Spawn Count Reached");
            return;
        }
        Instantiate(spawnPrefab,transform.position,Quaternion.identity,transform);
        spawnCount++;
    }
    #endregion
    #region MonoBehaviourFunctions
    void Update()
    {
        if (autoSpawn)
            SpawnClock();
    }
    #endregion

}
