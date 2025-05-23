using UnityEngine;

public class IntroMenu : MonoBehaviour
{
    public GameObject introCanvas;
    public float CutsceneTimer;
    public static bool isBeginning;
    void Start()
    {
        isBeginning = true;
        CutsceneTimer = 5f;
        //Time.timeScale = 0f;
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
        if (CutsceneTimer > 0f)
        {
            CutsceneTimer -= Time.deltaTime;
            if (CutsceneTimer <= 0f)
            {
                CutsceneTimer = 0f;
            }
        }
        if (Input.anyKeyDown && CutsceneTimer == 0)
        {
            isBeginning = false;
            introCanvas.SetActive(false);
            this.enabled = false;
            Time.timeScale = 1f;

        }
    }
}