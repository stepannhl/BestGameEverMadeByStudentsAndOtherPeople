using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuButton : MonoBehaviour
{
    public GameObject pauseMenuButton;
    public GameObject PauseMenu;
    public string ButtonName;

    private void OnMouseUpAsButton()
    {
        switch (ButtonName)
        {
            case "MenuButton":
                PauseMenu.SetActive(true);
                pauseMenuButton.SetActive(false);
                Time.timeScale = 0f;
                break;

            case "Resume":
                PauseMenu.SetActive(false);
                pauseMenuButton.SetActive(true);
                Time.timeScale = 1f;
                break;

            case "Quit":
                Time.timeScale = 1f;
                pauseMenuButton.SetActive(true);
                SceneManager.LoadScene("Menu");
                break;
        }

        
    }
}
