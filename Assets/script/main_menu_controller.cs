using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu_controller : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }


    public void QuitGame() 
    {
        Application.Quit();
    }
}
