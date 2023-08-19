using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _speedLerp;

    private Image _image;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ToFilling()
    {
        StartCoroutine(Filling(0, 1, _speedLerp, Filling));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(1, 0, _speedLerp, Empty));
    }


    private IEnumerator Filling(float startValue,float endValue, float durationLerp, UnityAction<float> lerpEnd)
    {
        float elepsed = 0;
        float nextTime;

        while (elepsed< durationLerp)
        {
            nextTime = Mathf.Lerp(startValue, endValue, elepsed / durationLerp);
            _image.fillAmount = nextTime;

            elepsed += Time.deltaTime;

            yield return null;
        }

        lerpEnd?.Invoke(endValue);
    }

    private void Filling(float value)
    {
        _image.fillAmount = value;
    }

    private void Empty(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

}
