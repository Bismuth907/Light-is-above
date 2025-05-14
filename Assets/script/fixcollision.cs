using UnityEngine;

public class fixcollision : MonoBehaviour
{
    public GameObject child;

    public Transform parent;
    void OnCollisionEnter2D(Collision2D collision)
    {
        child.transform.SetParent(parent);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        child.transform.SetParent(null);
    }
}
