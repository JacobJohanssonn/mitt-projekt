using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Controller : MonoBehaviour
{

    public List<GameObject> players = new List<GameObject>();
    public float movementLimit = 0;
    public GameObject textMesh;

    public Transform view;

    private bool isFlipped = false;

    private enum States
    {
        Play,
        Pause
    }

    public GameObject PauseMenu;
    private States State;

    bool finished = false;
    bool defeated = false;
    public GameObject CompletedMenu;
    public GameObject DefeatedMenu;
    
    void Start()
    {
        foreach (Transform child in transform)
        {
            if(child.gameObject.GetComponent<PlayerController>() != null)
            {
                players.Add(child.gameObject);
            }
        }

        State = States.Play;
    }

    // Update is called once per frame
    void Update()
    {
        finished = players.All(obj =>
            obj.GetComponent<PlayerController>().State == PlayerController.States.Finished);

        if (finished)
        {
            CompletedMenu.SetActive(true);
            State = States.Pause;
            return;
        }

        if(movementLimit <= 0)
        {
            foreach(GameObject player in players)
            {
                player.GetComponent<PlayerController>().Defeat();
            }
        }

        defeated = players.All(obj =>
            obj.GetComponent<PlayerController>().State == PlayerController.States.Defeated);

        if (defeated)
        {
            DefeatedMenu.SetActive(true);
            State = States.Pause;
            return;
        }
        if (Keyboard.current.escapeKey.wasPressedThisFrame && State != States.Pause)
        {
            State = States.Pause;
        }
        else if(Keyboard.current.escapeKey.wasPressedThisFrame && State == States.Pause)
        {
            State = States.Play;
        }
        if(State != States.Pause)
        {
            Pause(false);
            textMesh.GetComponent<TMP_Text>().text = movementLimit.ToString();

            int horizontalInput = 0;
            int verticalInput = 0;

            if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
            {
                horizontalInput = -1;
            }
            else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
            {
                horizontalInput = 1;
            }

            if (Keyboard.current.upArrowKey.wasPressedThisFrame)
            {
                verticalInput = 1;
            }
            else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
            {
                verticalInput = -1;
            }

            if (horizontalInput != 0 || verticalInput != 0)
            {
                bool anyMoved = false;

                foreach (GameObject player in players)
                {
                    PlayerController pc = player.GetComponent<PlayerController>();

                    if (pc.CanMove(horizontalInput, verticalInput))
                    {
                        pc.Move(horizontalInput, verticalInput);
                        anyMoved = true;
                    }
                }

                if (anyMoved)
                {
                    movementLimit -= 1f;
                }
            }

            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
        else
        {
            Pause(true);
        }
    }

    public void Pause(bool active)
    {
        if(active == true)
        {
            PauseMenu.SetActive(true);
            State = States.Pause;
        }
        else
        {
            PauseMenu.SetActive(false);
            State = States.Play;
        }
    }

    public void FlipView()
    {
        if (!isFlipped)
        {
            isFlipped = true;
        }
        else
        {
            isFlipped = false;
        }

        Vector3 rotation = view.localEulerAngles;
        rotation.y = isFlipped ? 180f : 0f;
        view.localEulerAngles = rotation;
    }

    public void UpsideDown(bool isUpsideDown)
    {
        Vector3 rotation = view.localEulerAngles;
        rotation.x = isUpsideDown ? 180f : 0f;
        view.localEulerAngles = rotation;
    }
}
