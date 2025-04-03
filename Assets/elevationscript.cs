using UnityEngine;
using System.Collections;

public class elevationscript : MonoBehaviour
{

    public float forceApplied = 50;

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Collision!");
        if (col.gameObject.name == "Player")
        {
            Debug.Log("chdjfc");
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * forceApplied, ForceMode2D.Impulse);
        }
    }
}
