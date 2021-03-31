using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    private float nextSpawnTime = 0.5f;    
    public Spawn spawn;
    
    void Update()
    {
        if(Time.time >= nextSpawnTime)
        {
            SpawnObj();
            nextSpawnTime = Time.time + 1f / spawn.spawnRate;
        }
    }
    void SpawnObj()
    {
        foreach(ObjectType objectType in spawn.objects)
        {
            if(Random.value <= objectType.spawnChance)
            {
                SpawnEnemy(objectType.objPrefab);
            }
        }
    }
    void SpawnEnemy(GameObject objPrefab)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-10, 10), -5, Random.Range(8, 15));        
        Instantiate(objPrefab, spawnPos, Quaternion.identity);
    }
}
