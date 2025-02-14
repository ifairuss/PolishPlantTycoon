using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New machine", menuName = "Add new items/New machine", order = 0)]
public class MachinePresetInfo : ScriptableObject
{
    public int ID;

    [Header("Machine create box preferences")]
    public float TimeToCreateBox;
    public int MaxBoxStorage;
    public int BotPrice;

    [Header("Machine components")]
    public GameObject BoxPrefab;
    public Sprite WarningImage;
    public Sprite ProgressBarImage;
}
