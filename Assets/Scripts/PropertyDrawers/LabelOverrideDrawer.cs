using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LabelOverrideAttribute))]
public class LabelOverrideDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        LabelOverrideAttribute labelOverride = (LabelOverrideAttribute)attribute;
        label.text = labelOverride.label;
        EditorGUI.PropertyField(position, property, label);
    }
}
