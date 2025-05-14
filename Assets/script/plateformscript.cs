using UnityEngine;

public class plateformscript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float relPos;
    void Start ()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        relPos = transform.position.x - collision.gameObject.transform.position.x;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plateform") && rigidbody2D.linearVelocity.x == 0f)
         { 
         transform.position = new Vector2 (collision.transform.position.x + relPos, transform.position.y);
        }
        if (collision.gameObject.CompareTag("plateform") && rigidbody2D.linearVelocity.x != 0f)
        {
            relPos = transform.position.x - collision.gameObject.transform.position.x;
        }
    }
}
