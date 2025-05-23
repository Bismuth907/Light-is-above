using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class lightbar : MonoBehaviour
{
    public float Interval = 1f;
    private float _timer = 0f;
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= Interval)
        {
            if (playercontroller.Health > 0 && IntroMenu.isBeginning == false)
            {
                playercontroller.Health -= 0.008f;
            }

            _timer = 0f;
        }
        if (playercontroller.Health == 0)
        {
            gameObject.GetComponent<respawnsystem>().Die();
        }
    }
    
}
