using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class Controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public List<GameObject> players = new List<GameObject>();
    void Start()
    {
        foreach (Transform child in transform)
        {
            if(child.gameObject.GetComponent<PlayerController>() != null)
            {
                players.Add(child.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int horizontalInput = 0;
        int verticalInput = 0;

        if(Keyboard.current.leftArrowKey.isPressed)
        {
            horizontalInput = -1;
        }
        else if(Keyboard.current.rightArrowKey.isPressed)
        {
            horizontalInput = 1;
        }

        if(Keyboard.current.upArrowKey.isPressed)
        {
            verticalInput = 1;
        }
        else if(Keyboard.current.downArrowKey.isPressed)
        {
            verticalInput = -1;
        }

        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerController>().Move(horizontalInput, verticalInput);
        }
    }
}
