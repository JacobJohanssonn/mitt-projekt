using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    public List<Transform> Buttons = new List<Transform>();
    public Transform Select_Button;
    public AudioSource SelectAudio;
    int i = 0;

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
                Restart();
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

    public void Restart()
    {
        SelectAudio.Play();
        StartCoroutine(SceneAfterSound(SceneManager.GetActiveScene().name));
    }

    public void Quit()
    {
        SelectAudio.Play();
        StartCoroutine(SceneAfterSound("MainMenu"));
    }

    private System.Collections.IEnumerator SceneAfterSound(string scene)
    {
        yield return new WaitForSeconds(SelectAudio.clip.length);
        PlayerPrefs.SetString("SceneToLoad", scene);
        SceneManager.LoadScene("LoadingScreen");
    }

    public void Hover(int buttonNumber)
    {
        i = buttonNumber;
    }
}
