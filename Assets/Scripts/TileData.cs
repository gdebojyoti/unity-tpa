using UnityEngine;

[System.Serializable]
public class TileData
{
    public Vector2 position;
    public int tileType; // You can use an enum or string to represent the tile type
    // randomly generated ID
    public string id;

    public TileData(Vector2 position, int tileType)
    {
        this.position = position;
        this.tileType = tileType;
        id = System.Guid.NewGuid().ToString();
    }
}
