using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField] private PlayerStats basePlayerStats;

    private PlayerStats playerStats;
    
    public static Action<PlayerStats> onStatsChange;


    private void Start()
    {
        playerStats = PlayerStats.CreateInstance(basePlayerStats);
        onStatsChange?.Invoke(playerStats);
    }


    public void UpdateStats(PlayerStats _playerStats)
    {
        playerStats.maxHealth += _playerStats.maxHealth;
        playerStats.damage += _playerStats.damage;
        playerStats.speed += _playerStats.speed;
        playerStats.fireRate += _playerStats.fireRate;

        onStatsChange?.Invoke(playerStats);
    }

}