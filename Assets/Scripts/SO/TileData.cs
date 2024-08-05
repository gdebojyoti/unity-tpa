using UnityEngine;

[CreateAssetMenu(fileName = "TileData", menuName = "Tiles/TileData", order = 1)]
public class TileData : ScriptableObject
{
    public TileTypes tileType;
    // public string packId; // reference to the theme to which this asset belongs
    public GameObject prefab;
}
