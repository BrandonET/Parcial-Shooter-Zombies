using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PoolManager : MonoBehaviour
{
    private List<GameObject> pool;
    public GameObject pooledObject;
    public int amount;

    public void Initialize()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(pooledObject, transform.position, Quaternion.identity, transform);
            obj.SetActive(false);
            pool.Add(obj);
        }

    }


    public GameObject ActiveNextObject()
    {
        GameObject returnedObj = null;

        foreach (GameObject objPool in pool)
        {
            if (!objPool.activeInHierarchy)
            {
                objPool.SetActive(true);
                returnedObj = objPool;
                break;
            }
        }
        return returnedObj;
    }
    public int GetPoolLenght()
    {
        return pool.Count;
     }
    public List<GameObject> GetPool()
    {
        return pool;
    }
}

        

