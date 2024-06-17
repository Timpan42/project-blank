using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SelectTileMap : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private float offset = 0.5f;
    [SerializeField] private Vector2 gridSize = new Vector2(1f, 1f);

}
