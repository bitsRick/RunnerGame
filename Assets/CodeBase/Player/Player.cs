using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> ChangedHealth;
    public event UnityAction Died;

    private void Start()
    {
        ChangedHealth?.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        ChangedHealth?.Invoke(_health);

        if (_health <= 0) 
            Die();
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
