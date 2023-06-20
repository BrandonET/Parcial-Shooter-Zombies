using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PoolManager poolManager;
    public List<GameObject> spawnpoints;

    private void start()
    {
        poolManager.Initialize();

        foreach (var item in poolManager.GetPool())
        {
            item.SetActive(true);
        }
    }
}