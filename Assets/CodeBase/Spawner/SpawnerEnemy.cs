using UnityEngine;

namespace CodeBase.Spawner
{
    public class SpawnerEnemy:global::Spawner
    {
        [SerializeField] private GameObject[] _enemy;
        [SerializeField] private float _timeSpawn;

        private void Start()
        {
            Initialization(_enemy);
        }

        private void Update()
        {
            if(TryGetTimeSpawn(_timeSpawn))
            {
                if (TryGetObject(out GameObject template))
                {
                    int randomPosition = Random.Range(0, SpawnPoints.Length);
                    template.transform.position = SpawnPoints[randomPosition].position;
                    template.gameObject.SetActive(true);
                }
            }
        }
    }
}