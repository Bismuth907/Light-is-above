using UnityEngine;
using UnityEngine.SceneManagement;

public class end_screen_launcher : MonoBehaviour
{
    void OnTriggerEnter2D() 
    {
        Debug.Log("33 huitre sur le canap�");
        SceneManager.LoadSceneAsync(2);
    }
}
