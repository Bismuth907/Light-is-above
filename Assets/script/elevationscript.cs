using UnityEngine;

public class elevationscript : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public GameObject _player;

    public float forceApplied = 50;
    private void Awake()
    {
        _player = GameObject.Find("Player");
        _rigidbody = _player.GetComponent<Rigidbody2D>();
    }
        void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Collision!");
        if (col.gameObject.name == "Player")
        {
            Debug.Log("chdjfc");
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * forceApplied, ForceMode2D.Impulse);
        }
        _rigidbody.gravityScale = 3;
    }
}
