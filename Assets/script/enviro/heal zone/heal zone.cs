using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class healzone : MonoBehaviour
{
    public Slider slider;
    public float Interval = 2f;
    private float _timer = 0f;
    private void OnTriggerEnter2D()
    {
        _timer += Time.deltaTime;
        if (_timer >= Interval) ;
        {
            if (slider.value > 0)
            {
                slider.value += 1;
            }

            _timer = 0f;
        }
    }
    private void OnTriggerStay2D()
    {
        _timer += Time.deltaTime;
        Debug.Log("ok");
        if (_timer >= Interval) ;//ça marche mieux avec les ";" et jsp pk
        {
            if (slider.value > 0)
            {
                slider.value += 1;
            }

            _timer = 0f;
        }
    }
}
