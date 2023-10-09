using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Platform : MonoBehaviour
{
    [Header("Platform Data")]
    [SerializeField] private WaveData[] waves;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] public Material portalMaterial;
    [SerializeField] public GameObject portals;
    [SerializeField] public GameObject chest;

    [Header("Enemy spawn range")]
    [SerializeField] private float spawnRadius;
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;

    [Header("Player spawn position")]
    [SerializeField] public Transform playerSpawn;

    private int currentWaveId;
    private float waveTimer;
    
    public bool isCompleted;


    private void OnEnable()
    {
        portals.SetActive(false);
        chest.SetActive(false);
        currentWaveId = 0;
        isCompleted = false;
    }

    private void Update()
    {
        if (!isCompleted)
        {
            waveTimer += Time.deltaTime;
        }
        CheckIsCompleted();

        GetRandomNavMeshPoint();
    }

    private void CheckIsCompleted()
    {
        if (currentWaveId >= waves.Length)
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, 50f, enemyLayer);

            if (enemies.Length <= 0)
            {
                isCompleted = true;
            }
        }
    }

    public void StartNewWave()
    {
        if (currentWaveId < waves.Length)
        {
            SpawnWave();
            currentWaveId++;
            waveTimer = 0;
        }
        else
        {
            Debug.Log("Nig");
        }
    }

    public bool IsWaveReady()
    {
        if (currentWaveId < waves.Length)
        {
            if (waveTimer >= waves[currentWaveId].duration)
            {
                return true;
            }
        }
        return false;
    }

    private void SpawnWave()
    {
        Debug.Log("Spawning Wave: " + (currentWaveId + 1) + " Out of: " + waves.Length);
        foreach (PoolType enemy in waves[currentWaveId].enemies)
        {
            PoolManager.Instance.SpawnFromPool(enemy, new Vector3(Random.Range(xMin, xMax), 2, Random.Range(yMin, yMax)), Quaternion.identity);
        }
    }

    private Vector3 GetRandomNavMeshPoint()
    {
        Vector3 randomPoint = Random.insideUnitSphere+ transform.position * spawnRadius;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, spawnRadius, NavMesh.AllAreas))
        {
            
            return hit.position;
        }
        else
        {
            return Vector3.zero;
        }
    }

}
