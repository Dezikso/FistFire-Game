using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerStats", menuName ="ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float maxHealth;
    public float currentHealth;
    public float damage;
    public float speed;
    public float projectileSpeed;
    public float fireRate;


    private void Initialize(PlayerStats _playerStats)
    {
        this.maxHealth = _playerStats.maxHealth;
        this.damage = _playerStats.damage;
        this.speed = _playerStats.speed;
        this.projectileSpeed = _playerStats.projectileSpeed;
        this.fireRate = _playerStats.fireRate;
    }

    public static PlayerStats CreateInstance(PlayerStats _playerStats)
    {
        var data = ScriptableObject.CreateInstance<PlayerStats>();
        data.Initialize(_playerStats);
        return data; 
    }
}
