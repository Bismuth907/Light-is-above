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
        Die();
    }
    private void Die()
    {
        Debug.Log($"{player} est détruit !");
        Destroy(player);
    }
}
