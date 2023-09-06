using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    #region Singleton
    public static PlayerStatsManager Instance { get; private set; }
    private void InitializeSingleton()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion

    [SerializeField] private ProjectileStats baseProjectileStats;
    private ProjectileStats projectileStats;
    public ProjectileStats ProjectileStats{ get{return projectileStats;} }


    private void Awake()
    {
        InitializeSingleton();
        projectileStats = ProjectileStats.CreateInstance(baseProjectileStats);
    }


    public void UpdateProjectileStats(ProjectileStats _projectileStats)
    {
        projectileStats.damage += _projectileStats.damage;
        projectileStats.speed += _projectileStats.speed;
        projectileStats.fireRate += _projectileStats.fireRate;
        projectileStats.critRate += _projectileStats.critRate;
        projectileStats.critDamage += _projectileStats.critDamage;
    }

}
