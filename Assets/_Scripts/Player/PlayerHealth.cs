using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    private PlayerStats playerStats;
    private float health;

    public static Action<float> onHealthChange;
    public static Action onPlayerDeath;

    private void OnEnable()
    {
        PlayerStatsManager.onStatsChange += UpdateStats;
    }
    
    private void OnDisable()
    {
        PlayerStatsManager.onStatsChange -= UpdateStats;
    }

    private void Start()
    {
        health = playerStats.maxHealth;
        onHealthChange?.Invoke(health);
    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0, playerStats.maxHealth);
    }

    private void UpdateStats(PlayerStats stats)
    {
        playerStats = stats;
    }

    public void ChangeHealth(float _health)
    {
        health += _health;
        onHealthChange?.Invoke(health);
        IsDead();
    }

    private void IsDead()
    {
        if(health <= 0)
        {
            onPlayerDeath?.Invoke();
        }
    }

}
