using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class healzone : MonoBehaviour
{
    public float Interval = 2f;
    private float _timer = 0f;
    private void OnTriggerEnter2D()
    {
        _timer += Time.deltaTime;
        if (_timer >= Interval) ;
        {
            if (playercontroller.Health > 0f)
            {
                playercontroller.Health += 0.009f;
            }

            _timer = 0f;
        }
    }
    private void OnTriggerStay2D()
    {
        _timer += Time.deltaTime;
        Debug.Log("ok");
        if (_timer >= Interval) ;   //�a marche mieux avec les ";" et jsp pk
        {
            if (playercontroller.Health > 0f)
            {
                playercontroller.Health += 0.009f;
                
            }

            _timer = 0f;
        }
    }
}
