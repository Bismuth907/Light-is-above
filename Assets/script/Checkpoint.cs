using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    respawnsystem respawnsystem;
    public Animator _animator;
    private void Awake()
    {
        respawnsystem = GameObject.FindGameObjectWithTag("Player").GetComponent<respawnsystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            respawnsystem.UpdateCheckpoint(transform.position);
            _animator.SetBool("checkpoint", true);
        }
    }
}
