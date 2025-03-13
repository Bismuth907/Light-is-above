using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class lightbar : MonoBehaviour
{
    public Slider slider;
    public float Interval = 2f;
    private float _timer = 0f;
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= Interval)
        {
            if (slider.value > 0)
            {
                slider.value -= 1;
            }

            _timer = 0f;
        }
        if (slider.value == 0)
        {
            gameObject.GetComponent<respawnsystem>().Die();
        }
    }
    
}
