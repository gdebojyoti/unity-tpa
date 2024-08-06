using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuEvents : MonoBehaviour
{
    public TileDataContainer tileDataContainer;  // Reference to the TileDataContainer ScriptableObject
    private UIDocument uiDocument;
    private ClickToPlace clickToPlace; // Reference to ClickToPlace script
    private readonly List<Button> buttons = new(); // All buttons

    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        clickToPlace = FindObjectOfType<ClickToPlace>(); // Find the ClickToPlace script in the scene

        // Fill the buttons list with all buttons with class .tile-cta
        buttons.AddRange(uiDocument.rootVisualElement.Query<Button>().ToList());

        HandleButtonClick();
    }

    // Method to handle button click events
    private void HandleButtonClick() {
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
                    clickToPlace.SetCurrentTile(tileData);
                    Debug.Log($"Current tile set to: {buttonId}");
                }
                else {
                    Debug.Log($"Tile not found for button: {buttonId}");
                }
            });
        }
    }
}
