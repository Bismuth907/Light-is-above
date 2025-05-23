using UnityEngine;

public class ScreenLock : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }
}
