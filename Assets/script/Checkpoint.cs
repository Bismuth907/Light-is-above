using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    respawnsystem respawnsystem;
    public Animator _animator;
    public GameObject Light;
    private void Awake()
    {
        respawnsystem = GameObject.FindGameObjectWithTag("Player").GetComponent<respawnsystem>();
        
    }
    private void Start()
    {
        Light.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            respawnsystem.UpdateCheckpoint(transform.position);
            _animator.SetBool("checkpoint", true);
           Light.SetActive(true);
        }
    }
}
