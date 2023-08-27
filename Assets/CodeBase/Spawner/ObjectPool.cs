using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Spawner
{
    public class ObjectPool:MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capValue;

        private List<GameObject> _pool = new List<GameObject>();

        protected void Initialization(GameObject[] template)
        {
            for (int i = 0; i < _capValue; i++)
            {
                int randomEnemy = Random.Range(0, template.Length);
                
                GameObject enemyTemplate = Instantiate(template[randomEnemy], _container.transform);
                enemyTemplate.SetActive(false);
                
                _pool.Add(enemyTemplate);
            }
        }

        protected bool TryGetObject(out GameObject template)
        {
            template = _pool.FirstOrDefault(
                p => p.gameObject.activeSelf == false);

            return template != null;
        }
    }
}