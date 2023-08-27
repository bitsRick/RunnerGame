using UnityEngine;

namespace CodeBase.Spawner
{
    public class SpawnerBonus:global::Spawner
    {
        [SerializeField] private GameObject[] _bonus;
        [SerializeField] private float _timeSpawn;

        private void Start()
        {
            Initialization(_bonus);
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