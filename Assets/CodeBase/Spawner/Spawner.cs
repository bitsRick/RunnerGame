
using System;
using CodeBase.Spawner;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class Spawner:ObjectPool
{
    [SerializeField] protected Transform[] SpawnPoints;

    private float _time;
    
    protected bool TryGetTimeSpawn(float timeSpawn)
    {
        _time += Time.deltaTime;
        
        if (_time >= timeSpawn)
        {
            _time = 0;
            return true;
        }
        
        return false;
    }
}