using UnityEngine;

[CreateAssetMenu(fileName = "TileDataContainer", menuName = "Tiles/TileDataContainer", order = 2)]
public class TileDataContainer : ScriptableObject
{
    public TileData[] tiles;
}
