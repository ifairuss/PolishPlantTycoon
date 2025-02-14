using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("Upgrade area")]
    [SerializeField] private Button _openUpgradeAreaButton;
    [SerializeField] private Button _upgradeAreaButton;
    [SerializeField] private Button _exitAreaButton;

    public Button OpenUpgradeAreaButton => _openUpgradeAreaButton;
    public Button UpgradeAreaButton => _upgradeAreaButton;
    public Button ExitAreaButton => _exitAreaButton;
}
