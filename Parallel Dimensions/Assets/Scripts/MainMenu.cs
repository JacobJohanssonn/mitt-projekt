using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public List<Transform> Buttons = new List<Transform>();
    public Transform Select_Button;

    public GameObject OptionsMenu;
    public GameObject LevelsMenu;

    private bool isMenu = false;
    int i = 2;
    void Update()
    {
        if(isMenu == false)
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
                    Levels();
                }
                else if(i == 1)
                {
                    Options();
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
    }

    public void Levels()
    {
        Levels(true);
    }

    public void Options()
    {
        Options(true);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Hover(int buttonNumber)
    {
        i = buttonNumber;
    }

    public void Options(bool active)
    {
        OptionsMenu.SetActive(active);
        isMenu = active;
    }
    public void Levels(bool active)
    {
        LevelsMenu.SetActive(active);
        isMenu = active;
    }
}
