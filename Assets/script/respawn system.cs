using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class respawnsystem : MonoBehaviour
{
    public Slider slider;
    Vector2 startPos;
    private void Start()
    {
        startPos = transform.position;
    }

    public void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = startPos;
        slider.value = 100;
    }
    
}
