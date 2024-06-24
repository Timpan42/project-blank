using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField] private int walkLength = 1;
    [SerializeField] private Vector3 offset;


    public void arrowWalk(InputAction moveInput)
    {
        moveDirection = moveInput.ReadValue<Vector2>();
        transform.position += (Vector3)moveDirection * walkLength;
    }

    public void mouseMove(Vector3Int mousePosition)
    {
        transform.position = mousePosition + offset;
    }

}
