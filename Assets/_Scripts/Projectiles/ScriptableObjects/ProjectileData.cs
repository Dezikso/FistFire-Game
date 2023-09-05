using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "ScriptableObjects/ProjectileData")]
public class ProjectileData : ScriptableObject
{
    public float damage;
    public float speed;
    public float fireRate;
    public float critRate;
    public float critDamage;


    public void Initialize(float damage, float speed, float fireRate, float critRate, float critDamage)
    {
        this.damage = damage;
        this.speed = speed;
        this.fireRate = fireRate;
        this.critRate = critRate;
        this.critDamage = critDamage;
    }

    public static ProjectileData CreateInstance(float damage, float speed, float fireRate, float critRate, float critDamage)
    {
        var data = ScriptableObject.CreateInstance<ProjectileData>();
        data.Initialize(damage, speed, fireRate, critRate, critDamage);
        return data; 
    }
}
