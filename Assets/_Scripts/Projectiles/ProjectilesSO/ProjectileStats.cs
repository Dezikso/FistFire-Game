using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "ScriptableObjects/ProjectileData")]
public class ProjectileStats : ScriptableObject
{
    public float damage;
    public float speed;
    public float fireRate;
    public float critRate;
    public float critDamage;


    private void Initialize(ProjectileStats _projectileData)
    {
        this.damage = _projectileData.damage;
        this.speed = _projectileData.speed;
        this.fireRate = _projectileData.fireRate;
        this.critRate = _projectileData.critRate;
        this.critDamage = _projectileData.critDamage;
    }

    public static ProjectileStats CreateInstance(ProjectileStats _projectileData)
    {
        var data = ScriptableObject.CreateInstance<ProjectileStats>();
        data.Initialize(_projectileData);
        return data; 
    }

}
