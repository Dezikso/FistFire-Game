using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private WaveData[] waves;

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
            Debug.Log("Spawning Wave: " + (currentWaveId + 1) + " Out of: " + waves.Length);
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

}
