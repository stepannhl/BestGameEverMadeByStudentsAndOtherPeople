using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public string action;
    private void OnMouseUpAsButton()
    {
        switch (action)
        {
            case "Exit":
                Application.Quit();
                break;
            case "Play":
                
                SceneManager.LoadScene("Main");
                break;
        }
    }
}


