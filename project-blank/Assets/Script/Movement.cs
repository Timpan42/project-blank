using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField] private int walkLength = 1;
    [SerializeField] private int speed = 1;
    [SerializeField] private Vector3 offset;
    private bool isMoveToOn = false;
    private Coroutine corMoveTo;

    public void arrowWalk(InputAction moveInput)
    {
        moveDirection = moveInput.ReadValue<Vector2>();
        transform.position += (Vector3)moveDirection * walkLength;
    }

    public void mouseMove(Vector3Int mousePosition)
    {
        if (!isMoveToOn)
        {
            corMoveTo = StartCoroutine(moveTo(mousePosition + offset));
        }
        else
        {
            StopCoroutine(corMoveTo);
            corMoveTo = StartCoroutine(moveTo(mousePosition + offset));
        }

    }

    private IEnumerator moveTo(Vector3 endPoint)
    {
        isMoveToOn = true;
        while (transform.position != endPoint)
        {
            float step = speed * Time.deltaTime;
            if (transform.position.y != endPoint.y)
            {
                step = step / 2;
            }
            Debug.Log(step);
            transform.position = Vector3.MoveTowards(transform.position, endPoint, step);
            yield return new WaitForEndOfFrame();
        }
        isMoveToOn = false;
        yield return null;
    }

}
