using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class plateformscript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    void Start ()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plateform"))
        { 
         rigidbody2D.velocity = collision.gameObject.velocity;
        }
    }

}
