using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform MovePoint;
    public LayerMask whatStopsMovement;
    public LayerMask Doors;
    public LayerMask Button;
    public float moveSpeed = 5f;

    public enum States
    {
        Controllable,
        Finished,
        Defeated
    }
    public States State;
    void Start()
    {
        MovePoint = transform.GetChild(0).gameObject.transform;
        MovePoint.parent = null;
        State = States.Controllable;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, MovePoint.position, moveSpeed * Time.deltaTime);
        if(Physics2D.OverlapCircle(transform.position, .2f, Doors))
        {
            State = States.Finished;
            return;
        }

        Collider2D hit = Physics2D.OverlapCircle(transform.position, .2f, Button);

        if(hit != null)
        {
            StandButton button = hit.GetComponent<StandButton>();

            if(button != null)
            {
                button.Button();
            }
        }
    }

    public bool CanMove(int horizontalInput, int verticalInput)
    {
        if (State != States.Controllable)
            return false;

        if (Vector3.Distance(transform.position, MovePoint.position) > 0.01f)
            return false;

        Vector3 targetPosition = MovePoint.position +
            new Vector3(horizontalInput, verticalInput, 0f);

        return !Physics2D.OverlapCircle(
            targetPosition, 0.2f, whatStopsMovement
        );
    }

    public void Move(int horizontalInput, int verticalInput)
    {
        if (CanMove(horizontalInput, verticalInput))
        {
            MovePoint.position += new Vector3(
                horizontalInput, verticalInput, 0f
            );
        }
    }

    public void Defeat()
    {
        if(State == States.Finished)
        {
            return;
        }
        State = States.Defeated;
    }
}