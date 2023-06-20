using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{
    public PoolManager poolManager;
    public Transform bulletSpawnPoint;

    private void Start()
    {
        poolManager.Initialize();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = poolManager.ActiveNextObject();
            bullet.transform.position = bulletSpawnPoint.position;

        }
    }
}
