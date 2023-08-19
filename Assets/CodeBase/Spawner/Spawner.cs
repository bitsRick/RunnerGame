
using System;
using CodeBase.Spawner;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class Spawner:ObjectPool
{
    [SerializeField] private GameObject[] _enemy;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _timeSpawn;

    private float _time;

    private void Start()
    {
        Inicilization(_enemy);
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _timeSpawn)
        {
            _time = 0;
            
            if (TryGetEnemy(out GameObject enemyTemplate))
            {
                int randomPosition = Random.Range(0, _spawnPoints.Length);
                enemyTemplate.transform.position = _spawnPoints[randomPosition].position;
                enemyTemplate.gameObject.SetActive(true);
            }
        }
    }
}