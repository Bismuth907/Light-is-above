using UnityEngine;

public class plateformscript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float relPos;
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        relPos = transform.position.x - collision.gameObject.transform.position.x;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plateform") && rb.linearVelocity.x == 0f)
         { 
         transform.position = new Vector2 (collision.transform.position.x + relPos, transform.position.y);
        }
        if (collision.gameObject.CompareTag("plateform") && rb.linearVelocity.x != 0f)
        {
            relPos = transform.position.x - collision.gameObject.transform.position.x;
        }
    }
}
