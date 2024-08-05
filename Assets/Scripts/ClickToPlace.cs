using System.Collections.Generic;
using UnityEngine;

public class ClickToPlace : MonoBehaviour
{
    // public GameObject tilePrefab;  // Reference to the tile prefab
    public TileManager tileManager;  // Reference to the TileManager
    private Camera mainCamera;      // Reference to the main camera
    private Dictionary<Vector2, GameObject> placedTiles; // Dictionary to keep track of placed tiles
    public List<MapTileData> mapTileDataList; // List to store tile data

    public TileTypes currentTileType = TileTypes.Ground; // Current tile type

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
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world coordinates
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // Convert position's float values to previous integer (floor)
            mousePosition.x = Mathf.Floor(mousePosition.x);
            mousePosition.y = Mathf.Floor(mousePosition.y);
            
            // Check if a tile already exists at the mouse position
            if (!placedTiles.ContainsKey(mousePosition))
            {
                // Getting a tile according the currently selected tile type
                GameObject tilePrefab = tileManager.GetTilePrefab(currentTileType);

                if (tilePrefab != null) {
                    // Instantiate the tile at the mouse position
                    GameObject newTile = Instantiate(tilePrefab, mousePosition, Quaternion.identity);

                    // Add the position and the tile to the dictionary
                    placedTiles.Add(mousePosition, newTile);

                    // Add the tile data to the list, according to the currently selected tile type
                    mapTileDataList.Add(new MapTileData(mousePosition, (int)currentTileType));
                }
            }
            else
            {
                Debug.Log("Tile already exists at this position.");
            }
        }
    }

    // Method to get the list of tile data (for future JSON export)
    public List<MapTileData> GetMapTileDataList()
    {
        return mapTileDataList;
    }
}
