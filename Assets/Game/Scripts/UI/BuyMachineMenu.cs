using System.Collections.Generic;
using UnityEngine;

public class BuyMachineMenu : MonoBehaviour
{
    [Header("Buy machine menu preferences")]
    [SerializeField] private List<ButtonBuyMachinePreferences> _allBuyMachineVariables;

    [Header("Components")]
    [SerializeField] private BuyMachineButton _buyMachineButtonPrefab;
    [SerializeField] private GameObject _buyMachineButtonStorage;

    public void Initialized()
    {
        for (int i = 0; i < _allBuyMachineVariables.Count; i++)
        {
            var button = Instantiate(_buyMachineButtonPrefab);
            button.transform.SetParent(_buyMachineButtonStorage.transform);
            button.SetPreferences(_allBuyMachineVariables[i]);
        }
    }
}
