using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TilePlacer : MonoBehaviour
{
    public TileManager tileManager; // Reference to the TileManager
    private Camera mainCamera; // Reference to the main camera
    private Dictionary<Vector2, GameObject> placedTiles; // Dictionary to keep track of placed tiles
    public List<MapTileData> mapTileDataList; // List to store tile data

    public TileData currentTile; // Current tile type

    void Start()
    {
        // If the main camera is not assigned, find it automatically
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Initialize the dictionary and the list
        placedTiles = new Dictionary<Vector2, GameObject>();
        mapTileDataList = new List<MapTileData>();
    }

    void Update()
    {
        HandleLeftClick();
    }

    private void HandleLeftClick()
    {
        // Check if the left mouse button is clicked and the pointer is not over a UI element
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            // Get the mouse position in world coordinates
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // Convert position's float values to previous integer (floor)
            mousePosition.x = Mathf.Floor(mousePosition.x);
            mousePosition.y = Mathf.Floor(mousePosition.y);

            PlaceTileAtPosition(mousePosition);
        }
    }

    // Method to place a tile at a given position, if one does not already exist
    private void PlaceTileAtPosition(Vector2 position)
    {
        if (!placedTiles.ContainsKey(position))
        {
            // Getting a tile according the currently selected tile type
                GameObject tilePrefab = tileManager.GetTilePrefab(currentTile.id);

                if (tilePrefab != null) {
                    // Instantiate the tile at the mouse position
                    GameObject newTile = Instantiate(tilePrefab, position, Quaternion.identity);

                    // Add the position and the tile to the dictionary
                    placedTiles.Add(position, newTile);

                    // Add the tile data to the list, according to the currently selected tile type
                    mapTileDataList.Add(new MapTileData(position, currentTile.id));
                }
        }
        else
        {
            Debug.Log("Tile already exists at this position!");
        }
    }

    // Method to get the list of tile data (for future JSON export)
    public List<MapTileData> GetMapTileDataList()
    {
        return mapTileDataList;
    }

    public void SetCurrentTile(TileData tileData)
    {
        currentTile = tileData;
    }

    // Method to get the list of tile data (for future JSON export)
    public List<MapTileData> GetTileDataList()
    {
        return mapTileDataList;
    }
}
