using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image healthBarFront;
    [SerializeField] private TextMeshProUGUI healthBarText;
    [SerializeField] private TextMeshProUGUI gameOverText;

    private PlayerStats playerStats;


    private void OnEnable()
    {
        PlayerStatsManager.onStatsChange += UpdateStats;
        PlayerHealth.onHealthChange += ChangeHealthUI;
        PlayerHealth.onPlayerDeath += DisplayGameOverUI;
    }
    
    private void OnDisable()
    {
        PlayerStatsManager.onStatsChange -= UpdateStats;
        PlayerHealth.onHealthChange -= ChangeHealthUI;
        PlayerHealth.onPlayerDeath -= DisplayGameOverUI;
    }


    private void UpdateStats(PlayerStats stats)
    {
        playerStats = stats;
    }

    private void ChangeHealthUI(float health)
    {
        healthBarFront.fillAmount = health/playerStats.maxHealth;
        healthBarText.text = health/playerStats.maxHealth * 100 + "%";
    }

    private void DisplayGameOverUI()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
