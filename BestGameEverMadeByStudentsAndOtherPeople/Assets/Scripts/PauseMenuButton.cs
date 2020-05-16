using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuButton : MonoBehaviour
{
    public GameObject PauseMenu;
    //public static bool GameIsPaused = false;
    public string ButtonName;

    private void OnMouseUpAsButton()
    {
        switch (ButtonName)
        {
            case "MenuButton":
                PauseMenu.SetActive(true);
                Time.timeScale = 0f;
                //GameIsPaused = true;
                break;

            case "Resume":
                PauseMenu.SetActive(false);
                Time.timeScale = 1f;
                //GameIsPaused = false;
                break;

            case "Quit":
                Time.timeScale = 1f;
                SceneManager.LoadScene("Menu");
                break;
        }

        
    }
}
