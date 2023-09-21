using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region Pool Class
    [System.Serializable]
    public class Pool
    {
        public PoolType poolType;
        public GameObject prefab;
        public int size;
    }
    #endregion

    #region Static Access
    public static PoolManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] private List<Pool> pools;
    [SerializeField]private Dictionary<PoolType, Queue<GameObject>> poolDictionary;


    private void Start()
    {
        poolDictionary = new Dictionary<PoolType, Queue<GameObject>>();

        InitializePools();
    }

    private void InitializePools()
    {
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.transform.parent = this.transform;
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.poolType, objectPool);
        }
    }

    public GameObject SpawnFromPool(PoolType poolType, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(poolType)) { return null; }

        GameObject objectToSpawn = poolDictionary[poolType].Dequeue();

        objectToSpawn.SetActive(false);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);

        poolDictionary[poolType].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

}

public enum PoolType
{
    //player projectiles
    Projectile,
    //enemy projectiles
    EnemyProjectile1,
    //enemies
    BasicEnemy
}
