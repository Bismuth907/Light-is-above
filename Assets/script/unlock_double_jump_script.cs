using UnityEngine;

public class unlock_double_jump_script : MonoBehaviour
{
    public GameObject triggerdoublejump;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playercontroller pc = collision.GetComponent<playercontroller>();
        if (pc != null)
        {
            pc.can_double_jump = false;
        }
        Destroy(triggerdoublejump);
    }
}