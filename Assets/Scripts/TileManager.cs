using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public TileDataContainer tileDataContainer;  // Reference to the TileDataContainer ScriptableObject
    private Dictionary<TileTypes, TileData> tileDataDictionary;

    void Awake()
    {
        // Initialize the dictionary
        tileDataDictionary = new Dictionary<TileTypes, TileData>();

        // Populate the dictionary with the data from the container
        foreach (TileData tileData in tileDataContainer.tiles)
        {
            tileDataDictionary[tileData.tileType] = tileData;
        }
    }

    // Method to get tile prefab based on type and variant
    public GameObject GetTilePrefab(TileTypes type)
    {
        if (tileDataDictionary.ContainsKey(type))
        {
            return tileDataDictionary[type].prefab;
        }
        return null;
    }
}
