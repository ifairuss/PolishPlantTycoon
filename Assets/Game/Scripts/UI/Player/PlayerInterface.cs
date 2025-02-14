using TMPro;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    [Header("UI Preferences")]
    [SerializeField] private TextMeshProUGUI _playerMoney;

    public void SetDispleyMoney(int playerMoney)
    {
        _playerMoney.text = $"${playerMoney}";
    }
}
