using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movment : MonoBehaviour
{
    private Movement playerMovement;
    private InputAction moveInput;
    private Vector2 moveDirection;
    [SerializeField] private int walkLength = 1;
    private void Awake() {
        playerMovement = new Movement();
    }

    private void OnEnable() {
        moveInput = playerMovement.Input.Move;
        moveInput.Enable();
    }

    private void Update() {
        if (moveInput.WasPressedThisFrame()) {
            moveDirection = moveInput.ReadValue<Vector2>();
            transform.position += (Vector3)moveDirection * walkLength;
        }
    }
}
