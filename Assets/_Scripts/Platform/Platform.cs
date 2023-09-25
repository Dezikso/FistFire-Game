using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Platform Data")]
    [SerializeField] private WaveData[] waves;
    [SerializeField] public Material portalMaterial;
    [SerializeField] public GameObject portals;

    [Header("Player spawn position")]
    [SerializeField] public Transform playerSpawn;

    [Header("Enemy spawn range")]
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;

    private int currentWaveId;
    private float waveTimer;
    
    public bool isCompleted;


    private void OnEnable()
    {
        portals.SetActive(false);
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
    }

    private void CheckIsCompleted()
    {
        if (currentWaveId >= waves.Length)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

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

}
