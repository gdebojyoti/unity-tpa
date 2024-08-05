using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuEvents : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button button;
    
    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        button = uiDocument.rootVisualElement.Q<Button>("soil") as Button;
        button.RegisterCallback<ClickEvent>(OnClick);
    }

    private void OnClick(ClickEvent evt)
    {
        Debug.Log("Button clicked!");
    }
}
