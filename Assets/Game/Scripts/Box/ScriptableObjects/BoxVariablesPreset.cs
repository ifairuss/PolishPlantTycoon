using UnityEngine;

[CreateAssetMenu(fileName = "New box", menuName = "Add new items/New box", order = 1)]

public class BoxVariablesPreset : ScriptableObject
{
    [Header("Box preferences")]
    public int Price;

    [Header("Box components")]
    public GameObject PrefabBox;
}
