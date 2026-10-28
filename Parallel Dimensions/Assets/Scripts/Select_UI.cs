using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Select_UI : MonoBehaviour
{
    public List<Transform> Buttons = new List<Transform>();
    public Transform Select_Button;
    int i = 2;

    public Controller controller;
    void Update()
    {
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            i++;
        }
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            i--;
        }

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            if(i == 2)
            {
                Continue();
            }
            else if(i == 1)
            {
                Restart();
            }
            else if(i == 0)
            {
                Quit();
            }
        }

        i = Mathf.Clamp(i, 0, Buttons.Count - 1);

        Select_Button.position = new Vector3(
            Select_Button.position.x,
            Buttons[i].position.y,
            Select_Button.position.z
        );
    }

    public void Continue()
    {
        controller.Pause(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        PlayerPrefs.SetString("SceneToLoad", "MainMenu");
        SceneManager.LoadScene("LoadingScreen");
    }

    public void Hover(int buttonNumber)
    {
        i = buttonNumber;
    }
}
