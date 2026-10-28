using UnityEngine;
using UnityEngine.Tilemaps;

public class Gates : MonoBehaviour
{
    private SpriteRenderer gate;

    public Sprite openGate;
    public Sprite closeGate;
    void Start()
    {
        gate = gameObject.GetComponent<SpriteRenderer>();
    }
    public void OpenGate()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        gate.sprite = openGate;

    }

    public void CloseGate()
    {
        gameObject.layer = LayerMask.NameToLayer("StopsMovement");
        gate.sprite = closeGate;
    }
}
