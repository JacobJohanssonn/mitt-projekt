using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform MovePoint;
    public LayerMask whatStopsMovement;
    public float moveSpeed = 5f;
    void Start()
    {
        MovePoint = this.transform.GetChild(0).gameObject.transform;
        MovePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(int horizontalInput, int verticalInput)
    {
        transform.position = Vector3.MoveTowards(transform.position, MovePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, MovePoint.position) <= 0.05f)
        {
            if(horizontalInput != 0)
            {
                if(!Physics2D.OverlapCircle(MovePoint.position + new Vector3(horizontalInput, 0f, 0f), .2f, whatStopsMovement))
                {
                    MovePoint.position += new Vector3(horizontalInput, 0f, 0f);
                }
            }
            else if(verticalInput != 0)
            {
                if(!Physics2D.OverlapCircle(MovePoint.position + new Vector3(0f, verticalInput, 0f), .2f, whatStopsMovement))
                {
                    MovePoint.position += new Vector3(0f, verticalInput, 0f);
                }
            }
        }
    }
}