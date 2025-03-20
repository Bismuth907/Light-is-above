using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class respawnsystem : MonoBehaviour
{
    public Slider slider;
    Vector2 checkpointPos;
    private void Start()
    {
        checkpointPos = transform.position;
    }

    public void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = checkpointPos;
        slider.value = 100;
    }
    public void UpdateCheckpoint(Vector2 pos) 
    {
        checkpointPos = pos;
    }
    
}
