using UnityEngine;

[System.Serializable]
public class MapTileData
{
    public Vector2 position;
    public string tileId; // You can use an enum or string to represent the tile type
    // randomly generated ID
    public string id;

    public MapTileData(Vector2 position, string tileId)
    {
        this.position = position;
        this.tileId = tileId;
        id = System.Guid.NewGuid().ToString();
    }
}
