using UnityEngine;

public class IntroMenu : MonoBehaviour
{
    public GameObject introCanvas;

    void Start()
    {
        Time.timeScale = 0f;
        if (PlayerPrefs.GetInt("FromRetry", 0) == 1)
        {
            introCanvas.SetActive(false);
            PlayerPrefs.SetInt("FromRetry", 0);
            PlayerPrefs.Save();
            return;
        }

        introCanvas.SetActive(true);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            introCanvas.SetActive(false);
            this.enabled = false;
            Time.timeScale = 1f;

        }
    }
}