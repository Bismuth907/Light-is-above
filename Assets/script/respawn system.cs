using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class respawnsystem : MonoBehaviour
{
    public Image Healthbarfiller;
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
        Healthbarfiller.fillAmount = 1f;
    }
    public void UpdateCheckpoint(Vector2 pos) 
    {
        checkpointPos = pos;
    }
    
}
