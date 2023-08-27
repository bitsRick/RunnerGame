using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public event UnityAction<int> ChangedHealth;
    public event UnityAction Died;

    private int _currentHealth;

    private void Start()
    {
        ChangedHealth?.Invoke(_maxHealth);
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        ChangedHealth?.Invoke(_currentHealth);

        if (_currentHealth <= 0) 
            Die();
    }

    public void TakeHealth()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth++;
            ChangedHealth?.Invoke(_currentHealth);   
        }
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
