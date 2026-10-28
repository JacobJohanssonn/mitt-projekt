using UnityEngine;
using UnityEngine.UI;

public class StandButton : MonoBehaviour
{
    public GameObject gameObjectGate;
    private Gates _gate;
    public Sprite pressedButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gate = gameObjectGate.GetComponent<Gates>();
    }

    public void Button()
    {
        _gate.OpenGate();
        gameObject.GetComponent<SpriteRenderer>().sprite = pressedButton;
    }
}
