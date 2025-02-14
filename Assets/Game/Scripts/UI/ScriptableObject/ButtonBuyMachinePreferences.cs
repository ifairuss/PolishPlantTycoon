using UnityEngine;

[CreateAssetMenu(fileName = "New machine button", menuName = "Add new items/New machine button", order = 0)]
public class ButtonBuyMachinePreferences : ScriptableObject
{
    [Header("Machine buy preferences")]
    public string MachineDescription;
    public int MachinePrice;

    [Header("Machine resources")]
    public Sprite MachineImage;
    public GameObject MachinePrefab;
}
