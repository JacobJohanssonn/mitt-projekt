using UnityEngine;
using UnityEngine.Tilemaps;

public class Gates : MonoBehaviour
{
    private SpriteRenderer gate;

    private enum State
    {
        Open,
        Closed
    }

    private State state;

    public Sprite openGate;
    public Sprite closeGate;
    private AudioSource OpenAudio;
    void Start()
    {
        state = State.Closed;
        gate = gameObject.GetComponent<SpriteRenderer>();
        OpenAudio = gameObject.GetComponent<AudioSource>();
    }
    public void OpenGate()
    {
        if(state == State.Open)
        {
            return;
        }
        gameObject.layer = LayerMask.NameToLayer("Default");
        gate.sprite = openGate;
        OpenAudio.Play();
        state = State.Open;
    }

    public void CloseGate()
    {
        if(state == State.Closed)
        {
            return;
        }
        gameObject.layer = LayerMask.NameToLayer("StopsMovement");
        gate.sprite = closeGate;
        state = State.Closed;
    }
}
