using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuEvents : MonoBehaviour
{
    public TileDataContainer tileDataContainer;  // Reference to the TileDataContainer ScriptableObject
    public TileDataExporter tileDataExporter; // Reference to the TileDataExporter script
    
    private UIDocument uiDocument;
    private TilePlacer tilePlacer; // Reference to TilePlacer script
    private Button saveButton; // Save button
    private readonly List<Button> buttons = new(); // All other buttons

    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        tilePlacer = FindObjectOfType<TilePlacer>(); // Find the TilePlacer script in the scene

        // Find button with #save-button ID
        saveButton = uiDocument.rootVisualElement.Q<Button>("save-map");

        // Fill the buttons list with all buttons with class .tile-cta
        buttons.AddRange(uiDocument.rootVisualElement.Query<Button>().ToList());

        HandleButtonClick();
    }

    // Method to handle button click events
    private void HandleButtonClick() {
        // Save button click event
        saveButton.RegisterCallback<ClickEvent>(evt => {
            tileDataExporter.ExportToJson("/map-data.json");
        });
        
        // for each button in the list
        foreach (Button button in buttons)
        {
            // get button ID
            string buttonId = button.name;

            // search inside the tileDataContainer for the tile whose ctaId matches the buttonId
            TileData tileData = tileDataContainer.tiles.FirstOrDefault(t => t.ctaId == buttonId);

            button.RegisterCallback<ClickEvent>(evt => {
                if (tileData != null)
                {
                    tilePlacer.SetCurrentTile(tileData);
                }
                else {
                    Debug.Log($"Tile not found for button: {buttonId}");
                }
            });
        }
    }
}
