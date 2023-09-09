using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthBarFront;
    [SerializeField] private TextMeshProUGUI healthBarText;

    private PlayerStats playerStats;
    private float health;

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
        ChangeHealthUI();
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
        ChangeHealthUI();
    }

    private void ChangeHealthUI()
    {
        healthBarFront.fillAmount = health/playerStats.maxHealth;
        healthBarText.text = (health/playerStats.maxHealth) * 100 + "%";
    }

}
