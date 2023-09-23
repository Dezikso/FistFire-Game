using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private WaveData[] waves;
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
        currentWaveId = 0;
        isCompleted = false;
    }

    private void Update()
    {
        if (!isCompleted)
        {
            waveTimer += Time.deltaTime;
        }
    }

    public void StartNewWave()
    {
        if (currentWaveId < waves.Length)
        {
            SpawnWave();
            currentWaveId++;
            waveTimer = 0;
            if (currentWaveId >= waves.Length)
            {
                isCompleted = true;
            }
        }
    }

    public bool IsWaveReady()
    {
        if (waveTimer >= waves[currentWaveId].duration)
        {
            return true;
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
