using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class CompleteMenu : MonoBehaviour
{
    public List<Transform> Buttons = new List<Transform>();
    public Transform Select_Button;

    public TMP_Text level_label;
    int i = 0;

    void Start()
    {
        string LevelName = SceneManager.GetActiveScene().name;
        int number = int.Parse(LevelName.Replace("Level", ""));
        level_label.text = "Level " + number + " is Completed!";
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            i++;
        }
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            i--;
        }

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            if(i == 0)
            {
                Next();
            }
            else if(i == 1)
            {
                Quit();
            }
        }
        i = Mathf.Clamp(i, 0, Buttons.Count - 1);

        Select_Button.position = new Vector3(
            Buttons[i].position.x,
            Select_Button.position.y,
            Select_Button.position.z
        );
    }

    public void Next()
    {
        string LevelNext = SceneManager.GetActiveScene().name;
        int number = int.Parse(LevelNext.Replace("Level", ""));
        number++;
        if (Application.CanStreamedLevelBeLoaded("Level" + number))
        {
            SceneManager.LoadScene("Level" + number);            
        }
        else
        {
            Debug.Log("No other level");
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Hover(int buttonNumber)
    {
        i = buttonNumber;
    }
}
