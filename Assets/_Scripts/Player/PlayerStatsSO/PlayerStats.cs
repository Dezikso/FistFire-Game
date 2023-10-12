using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerStats", menuName ="ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [Header("Player stats")]
    public float maxHealth;
    public float damage;
    public float speed;
    public float projectileSpeed;
    public float fireRate;
    public float dashCooldown;
    [HideInInspector] public float nextDashTime;
    

    private void Initialize(PlayerStats _playerStats)
    {
        this.maxHealth = _playerStats.maxHealth;
        this.damage = _playerStats.damage;
        this.speed = _playerStats.speed;
        this.projectileSpeed = _playerStats.projectileSpeed;
        this.fireRate = _playerStats.fireRate;
        this.dashCooldown = _playerStats.dashCooldown;
        this.nextDashTime = this.dashCooldown;
    }

    public static PlayerStats CreateInstance(PlayerStats _playerStats)
    {
        var data = CreateInstance<PlayerStats>();
        data.Initialize(_playerStats);
        return data; 
    }
}
