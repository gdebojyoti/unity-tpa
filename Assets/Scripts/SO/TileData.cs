using UnityEngine;

[CreateAssetMenu(fileName = "TileData", menuName = "Tiles/TileData", order = 1)]
public class TileData : ScriptableObject
{
    public TileTypes tileType;
    public string id;
    // public string packId; // reference to the theme to which this asset belongs
    public GameObject prefab;
    public string ctaId;

    private void OnEnable()
    {
        // Generate a unique ID if one does not already exist
        if (string.IsNullOrEmpty(id))
        {
            id = System.Guid.NewGuid().ToString();
        }
    }
}
