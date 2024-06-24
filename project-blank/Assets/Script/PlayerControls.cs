using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using Unity.IO.LowLevel.Unsafe;


public class PlayerControls : MonoBehaviour
{
    private Controls playerMovement;
    private InputAction mousePositionInput;
    private InputAction arrowMoveInput;
    private InputAction mouseMoveInput;
    private Vector2 mousePosition;
    [SerializeField] private Movement movementScript;
    [SerializeField] private Tilemap tilemap;
    private Vector3Int currentGridPosition;
    private Vector3Int lastGridPosition;
    [SerializeField] private Color32 transparentColor;

    private void Awake()
    {
        playerMovement = new Controls();
    }

    private void OnEnable()
    {
        mousePositionInput = playerMovement.Input.MousePosition;
        arrowMoveInput = playerMovement.Input.ArrowMove;
        mouseMoveInput = playerMovement.Input.MouseMove;
        mousePositionInput.Enable();
        arrowMoveInput.Enable();
        mouseMoveInput.Enable();
    }

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(mousePositionInput.ReadValue<Vector2>());
        currentGridPosition = tilemap.WorldToCell(mousePosition);
        mouseHover();
        if (arrowMoveInput.WasPressedThisFrame())
        {
            movementScript.arrowWalk(arrowMoveInput);
        }
        if (mouseMoveInput.WasPressedThisFrame())
        {
            movementScript.mouseMove(currentGridPosition);
        }

    }

    private void mouseHover()
    {
        if (currentGridPosition != lastGridPosition)
        {
            changeTileColor(lastGridPosition, Color.clear);
            lastGridPosition = currentGridPosition;
        }
        changeTileColor(lastGridPosition, transparentColor);

    }

    private void changeTileColor(Vector3Int gridPosition, Color newColor)
    {
        tilemap.SetTileFlags(gridPosition, TileFlags.None);
        tilemap.SetColor(gridPosition, newColor);
        tilemap.SetTileFlags(gridPosition, TileFlags.LockAll);
    }

}
