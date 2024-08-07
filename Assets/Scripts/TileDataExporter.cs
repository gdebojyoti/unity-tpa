using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class TileDataExporter : MonoBehaviour
{
    public TilePlacer clickToPlaceScript; // Reference to the TilePlacer script

    public void ExportToJson(string filePath)
    {
        List<MapTileData> tileDataList = clickToPlaceScript.GetTileDataList();
        string json = JsonUtility.ToJson(new TileDataWrapper { tiles = tileDataList });
        File.WriteAllText(Application.persistentDataPath + filePath, json);
    }
}

[System.Serializable]
public class TileDataWrapper
{
    public List<MapTileData> tiles;
}
