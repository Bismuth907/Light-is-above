using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class lightbar : MonoBehaviour
{
    public Image Healthbarfiller;
    public float Interval = 2f;
    private float _timer = 0f;
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= Interval)
        {
            if (Healthbarfiller.fillAmount > 0)
            {
                Healthbarfiller.fillAmount =- 0.008f;
            }

            _timer = 0f;
        }
        if (Healthbarfiller.fillAmount == 0)
        {
            gameObject.GetComponent<respawnsystem>().Die();
        }
    }
    
}
