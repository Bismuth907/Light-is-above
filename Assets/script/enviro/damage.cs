using UnityEngine;

public class damage : MonoBehaviour
{
    public GameObject player;
    public void Start()
    {
        player = GameObject.Find("Capsule");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       collision.gameObject.GetComponent<respawnsystem>().Die();
    }
}
