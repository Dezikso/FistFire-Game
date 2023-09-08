using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField] private PlayerStats basePlayerStats;

    private PlayerStats playerStats;
    public PlayerStats PlayerStats{ get{return playerStats;} }
    private float currentHealth;


    private void Awake()
    {
        playerStats = PlayerStats.CreateInstance(basePlayerStats);
        currentHealth = playerStats.maxHealth;
    }


    public void UpdateStats(PlayerStats _playerStats)
    {
        playerStats.maxHealth += _playerStats.maxHealth;
        playerStats.damage += _playerStats.damage;
        playerStats.speed += _playerStats.speed;
        playerStats.fireRate += _playerStats.fireRate;
    }

    public void ChangeHealth(float healthChange)
    {
        currentHealth += healthChange;

    }
}