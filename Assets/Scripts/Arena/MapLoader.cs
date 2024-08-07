using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public TileManager tileManager; // Reference to the TileManager script
    private string filePath;

    [System.Serializable]
    public class MapData
    {
        public List<MapTileData> tiles;
    }

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "map-data.json");
        LoadMap();
    }

    void LoadMap()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            MapData mapData = JsonUtility.FromJson<MapData>(json);

            foreach (MapTileData tileData in mapData.tiles)
            {
                GameObject tilePrefab = tileManager.GetTilePrefab(tileData.tileId);
                if (tilePrefab != null)
                {
                    GameObject newTile = Instantiate(tilePrefab, tileData.position, Quaternion.identity);

                    // Add a BoxCollider2D to the tile if it doesn't already have one
                    if (newTile.GetComponent<BoxCollider2D>() == null)
                    {
                        newTile.AddComponent<BoxCollider2D>();
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Map data file not found!");
        }
    }
}
