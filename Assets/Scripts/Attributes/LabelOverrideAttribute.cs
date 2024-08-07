using UnityEngine;

public class LabelOverrideAttribute : PropertyAttribute
{
    public string label;

    public LabelOverrideAttribute(string label)
    {
        this.label = label;
    }
}
