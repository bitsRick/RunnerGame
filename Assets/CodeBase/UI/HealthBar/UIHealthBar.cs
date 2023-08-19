using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace CodeBase.UI
{
    public class UIHealthBar:MonoBehaviour
    {
        [SerializeField] private Heart _templatHeart;
        [SerializeField] private Player _player;

        private List<Heart> _listHeart = new List<Heart>();
    
        private void OnEnable()
        {
            _player.ChangedHealth += ChangedHealth;
        }

        private void OnDisable()
        {
            _player.ChangedHealth -= ChangedHealth;
        }

        private void ChangedHealth(int healthCount)
        {
            if (_listHeart.Count < healthCount)
            {
                int healtToCreate = healthCount - _listHeart.Count;

                for (int i = 0; i < healtToCreate; i++)
                {
                    CreatedHeart();
                }
            }
            else if (healthCount < _listHeart.Count)
            {
                int healtToDestroy =  _listHeart.Count - healthCount;

                for (int i = 0; i < healtToDestroy; i++)
                {
                    DestroyHeart(_listHeart[_listHeart.Count - 1]);
                }
            }
        }

        private void CreatedHeart()
        {
            Heart heart = Instantiate(_templatHeart, transform);
            heart.ToFilling();

            _listHeart.Add(heart.GetComponent<Heart>());
        }

        private void DestroyHeart(Heart heart)
        {
            _listHeart.Remove(heart);
            heart.ToEmpty();
        }
    }
}