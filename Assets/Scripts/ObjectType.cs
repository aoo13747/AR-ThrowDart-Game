using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectType
{
    public GameObject objPrefab;
    [Range(0f, 1f)] public float spawnChance;
}
