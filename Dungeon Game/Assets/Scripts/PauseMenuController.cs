using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GameIsPaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
    }

    public void PauseGame()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
    }
}
