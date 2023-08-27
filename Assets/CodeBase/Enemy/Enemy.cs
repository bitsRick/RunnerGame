using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);
            Destroy();
        }

        if (collider2D.TryGetComponent(out DestroyGameObject _destroyGameObject)) 
            Destroy();
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
