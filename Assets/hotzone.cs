using UnityEngine;

public class hotzone : MonoBehaviour
{
    public GameObject heatzonewall;
    public GameObject triggerhotzone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(triggerhotzone);
        Destroy(heatzonewall);

    }
}
