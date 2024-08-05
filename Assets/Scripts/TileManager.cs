using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public TileDataContainer tileDataContainer;  // Reference to the TileDataContainer ScriptableObject
    private Dictionary<string, TileData> tileDataDictionary;

    void Awake()
    {
        // Initialize the dictionary
        tileDataDictionary = new Dictionary<string, TileData>();

        // Populate the dictionary with the data from the container
        foreach (TileData tileData in tileDataContainer.tiles)
        {
            tileDataDictionary[tileData.id] = tileData;
        }
    }

    // Method to get tile prefab based on tile ID
    public GameObject GetTilePrefab(string id)
    {
        if (tileDataDictionary.ContainsKey(id))
        {
            return tileDataDictionary[id].prefab;
        }
        return null;
    }
}
