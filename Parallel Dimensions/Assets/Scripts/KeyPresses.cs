
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class KeyPresses : MonoBehaviour
{
    [Header("GameObjects")]
    public Image R_Key;
    public Image leftArrow;
    public Image rightArrow;
    public Image upArrow;
    public Image downArrow;

    [Header("Sprites")]
    public Sprite R_KeySprite;
    public Sprite leftArrowSprite;
    public Sprite rightArrowSprite;
    public Sprite upArrowSprite;
    public Sprite downArrowSprite;

    [Header("Pressed Sprites")]
    public Sprite Pressed_R_KeySprite;
    public Sprite Pressed_leftArrowSprite;
    public Sprite Pressed_rightArrowSprite;
    public Sprite Pressed_upArrowSprite;
    public Sprite Pressed_downArrowSprite;

    [Header("Settings")]
    public float PressDuration = 0.15f;

    void Start()
    {
        R_Key.sprite = R_KeySprite;
        leftArrow.sprite = leftArrowSprite;
        rightArrow.sprite = rightArrowSprite;
        upArrow.sprite = upArrowSprite;
        downArrow.sprite = downArrowSprite;
    }

    void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
            StartCoroutine(ChangeSprite(leftArrow, Pressed_leftArrowSprite, leftArrowSprite));

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
            StartCoroutine(ChangeSprite(rightArrow, Pressed_rightArrowSprite, rightArrowSprite));

        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
            StartCoroutine(ChangeSprite(upArrow, Pressed_upArrowSprite, upArrowSprite));

        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
            StartCoroutine(ChangeSprite(downArrow, Pressed_downArrowSprite, downArrowSprite));

        if (Keyboard.current.rKey.wasPressedThisFrame)
            StartCoroutine(ChangeSprite(R_Key, Pressed_R_KeySprite, R_KeySprite));
    }

    IEnumerator ChangeSprite(Image image, Sprite pressedSprite, Sprite normalSprite)
    {
        image.sprite = pressedSprite;

        yield return new WaitForSecondsRealtime(PressDuration);

        image.sprite = normalSprite;
    }
}
