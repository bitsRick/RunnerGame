using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Paralax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _rawImage;
    private float _positionX;

    private void Start()
    {
        _rawImage = GetComponent<RawImage>();
        _positionX = _rawImage.uvRect.x;
    }

    private void Update()
    {
        _positionX += _speed * Time.deltaTime;

        if (_positionX >= 1)
        {
            _positionX = 0;
        }

        _rawImage.uvRect = new Rect(_positionX,0,_rawImage.uvRect.width, _rawImage.uvRect.height);
    }
}
