using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _sizeMove;
    [SerializeField] private float _maxHight;
    [SerializeField] private float _minHeight;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (_targetPosition != transform.position)
            transform.position = Vector2.MoveTowards(
                transform.position,
                _targetPosition,
                _speed * Time.deltaTime);
    }

    public void MoveUp()
    {
        if (_maxHight > transform.position.y )
        {
            SetNewMovePosition(_sizeMove);
        }
    }

    public void MoveDown()
    {
        if (_minHeight < transform.position.y)
        {
            SetNewMovePosition(-_sizeMove);
        }
    }

    private void SetNewMovePosition(float sizeDistance)
    {
        _targetPosition = new Vector2(transform.position.x, transform.position.y + sizeDistance);
    }
}
